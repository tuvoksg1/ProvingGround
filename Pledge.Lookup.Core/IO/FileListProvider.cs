using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using Pledge.Common;
using Pledge.Common.Exceptions;
using Pledge.Common.Extensions;
using Pledge.Common.Models;
using Pledge.Common.Models.Lookup;

namespace Pledge.Lookup.Core.IO
{
    public class FileListProvider : AbstractListProvider
    {
        private const string _ruleMetaType = "rule";
        private const string _helpMetaType = "help";
        private const string _lookupFunction = "Lookup";
        private const string _helpFunction = "Help";

        public FileListProvider()
        {
            Type = ListType.FileSystem;
            ListFolder = Path.GetFullPath(ConfigurationManager.AppSettings[ListGlobal.TargetDirectory]);
            ListExtension = ConfigurationManager.AppSettings[ListGlobal.ListExtension];
            ListMetaDataExtension = ConfigurationManager.AppSettings[ListGlobal.ListMetaDataExtension];
            ListHelpName = ConfigurationManager.AppSettings[ListGlobal.ListHelpName];
        }

        private string ListFolder { get; }
        private string ListExtension { get; }
        private string ListMetaDataExtension { get; }
        private string ListHelpName { get; }

        public override IEnumerable<List> GetLists(string tenantId)
        {
            var tenantFolder = Directory.EnumerateDirectories(ListFolder).FirstOrDefault(path => path.EndsWith(tenantId));
            if (tenantFolder == null)
                return new List<List>();

            var listMetadataFiles = Directory.GetFiles(Path.Combine(ListFolder, tenantFolder), $"*.{ListMetaDataExtension}");
            var listsMetadata = listMetadataFiles.Select(ListMetadata.DeserializeFromFile);

            var ruleLists =
                listsMetadata.Where(list => list.Type.ToLower() == _ruleMetaType)
                    .Select(list => new List
                    {
                        Type = Type,
                        ListId = list.ListId,
                        Name = list.Name,
                        Description = list.Description,
                        Function = TranslateFunction(list.Type),
                        Separator = list.Separator
                    })
                    .OrderBy(list => list.Name)
                    .ToList();

            return ruleLists;
        }

        private static string TranslateFunction(string metaType)
        {
            if (string.Equals(metaType, _ruleMetaType)) return _lookupFunction;
            return _helpFunction;
        }

        private static string TranslateMetaType(string function)
        {
            if (string.Equals(function, _lookupFunction)) return _ruleMetaType;
            return _helpMetaType;
        }

        private static void ValidateList(ListMetadata listMetadata, string name, string tenantFolder)
        {
            if (!Directory.Exists(tenantFolder))
            {
                throw new PledgeMissingListFolderException(PledgeGlobal.ExceptionMissingListFolder);
            }

            if (listMetadata == null)
            {
                throw new PledgeMissingListMetadataException(PledgeGlobal.ExceptionMissingListMetadata + $": {name}");
            }

            if (!File.Exists(Path.Combine(tenantFolder, listMetadata.Location)))
            {
                var listName = Path.GetFileNameWithoutExtension(listMetadata.Name);
                throw new PledgeMissingListException(PledgeGlobal.ExceptionMissingList + $": {listName}");
            }
        }

        public override List<string> GetSingleColumnList(string listId, string name, string tenantId)
        {
            var listMetadata = new ListMetadata();

            var tenantFolder = name.Equals(ListHelpName, StringComparison.OrdinalIgnoreCase)
                ? ListFolder
                : Directory.EnumerateDirectories(ListFolder).FirstOrDefault(path => path.EndsWith(tenantId));

            if (tenantFolder != null)
            {
                var listMetadataFiles = Directory.GetFiles(tenantFolder, $"*.{ListMetaDataExtension}");
                var listsMetadata = listMetadataFiles.Select(ListMetadata.DeserializeFromFile);
                listMetadata = listsMetadata.FirstOrDefault(metadata => string.Equals(metadata.ListId, listId, StringComparison.CurrentCultureIgnoreCase));
            }

            ValidateList(listMetadata, name, tenantFolder);

            if (listMetadata != null)
                ColumnSeparators = new[] {listMetadata.Separator.DecodeDelimiter()};
            return listMetadata == null || tenantFolder == null ? null : new List(File.ReadAllLines(Path.Combine(tenantFolder, listMetadata.Location))).Content;
        }

        /// <summary>
        /// Deletes the list.
        /// </summary>
        /// <param name="listId">The list identifier.</param>
        /// <param name="tenantId">The tenant identifier.</param>
        public override void DeleteList(string listId, string tenantId)
        {
            var tenantFolder = Directory.EnumerateDirectories(ListFolder).First(path => path.EndsWith(tenantId));
            var listMetadataFiles = Directory.GetFiles(tenantFolder, $"*.{ListMetaDataExtension}");

            foreach (var file in listMetadataFiles)
            {
                var metadata = ListMetadata.DeserializeFromFile(file);

                if (metadata.ListId != listId) continue;

                File.Delete(Path.Combine(tenantFolder, metadata.Location));
                File.Delete(file);

                break;
            }
        }

        /// <summary>
        /// Get the id of the list from the supplied name.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="tenantId"></param>
        /// <returns></returns>
        public override string GetListId(string name, string tenantId)
        {
            var listMetadata = new ListMetadata();

            var tenantFolder = name.Equals(ListHelpName, StringComparison.OrdinalIgnoreCase)
                ? ListFolder
                : Directory.EnumerateDirectories(ListFolder).FirstOrDefault(path => path.EndsWith(tenantId));

            if (tenantFolder != null)
            {
                var listMetadataFiles = Directory.GetFiles(tenantFolder, $"*.{ListMetaDataExtension}");
                var listsMetadata = listMetadataFiles.Select(ListMetadata.DeserializeFromFile);
                listMetadata = listsMetadata.FirstOrDefault(metadata => string.Equals(metadata.Name, name, StringComparison.CurrentCultureIgnoreCase));
            }

            ValidateList(listMetadata, name, tenantFolder);

            return listMetadata?.ListId;
        }

        public override ListType Type { get; }

        public override void SaveList(List list)
        {
            var existingListMetadata = new ListMetadata();
            var existingMetadataFile = string.Empty;

            var tenantFolder = Directory.EnumerateDirectories(ListFolder).FirstOrDefault(path => path.EndsWith(list.TenantId));
            if (tenantFolder == null)
            {
                tenantFolder = Path.Combine(ListFolder, list.TenantId);
                Directory.CreateDirectory(tenantFolder);
            }
            else
            {
                var listMetadataFiles = Directory.GetFiles(tenantFolder, $"*.{ListMetaDataExtension}");

                foreach (var file in listMetadataFiles)
                {
                    var metadata = ListMetadata.DeserializeFromFile(file);

                    if (metadata.ListId != list.ListId) continue;

                    existingListMetadata = metadata;
                    existingMetadataFile = file;

                    break;
                }
            }

            var invalidFilenameCharacters = new Regex("[\\\\/:*?\"<>|]");
            var newListLoaded = list.FileData.Length > 0;
            var existingMetadata = existingListMetadata.ListId != null;
            var newMetaData = existingListMetadata.Name != list.Name || 
                existingListMetadata.Description != list.Description || 
                existingListMetadata.Separator != list.Separator ||
                existingListMetadata.Location != $"{invalidFilenameCharacters.Replace(list.Name, "")}_{list.ListId}.{ListExtension}";

            var listMetadata = new ListMetadata
            {
                ListId = list.ListId,
                Name = list.Name,
                Description = list.Description,
                Location = newListLoaded ?
                    $"{invalidFilenameCharacters.Replace(list.Name, "")}_{list.ListId}.{ListExtension}" :
                    existingListMetadata.Location,
                Type = TranslateMetaType(list.Function),
                Separator = list.Separator,
                UpdatedBy = "MaritzCX",
                LastUpdated = DateTime.UtcNow
            };

            if (newListLoaded)
            {
                if (existingMetadata)
                    File.Delete(Path.Combine(tenantFolder, existingListMetadata.Location));

                File.WriteAllBytes(Path.Combine(tenantFolder, listMetadata.Location ?? $"missing_{listMetadata.ListId}"), list.FileData);
            }

            if (newMetaData)
            {
                if (existingMetadata)
                    File.Delete(existingMetadataFile);

                listMetadata.SerializeToFile(Path.Combine(tenantFolder, $"{invalidFilenameCharacters.Replace(list.Name, "")}_{list.ListId}.{ListMetaDataExtension}"));
            }
        }

        public void GenerateMetadata(string filePath, bool addNewFiles, bool removeMissingFiles)
        {
            // Deserialize existing metadata
            var listMetadataFiles = Directory.GetFiles(filePath, $"*.{ListMetaDataExtension}");
            var listsMetadata = listMetadataFiles.Select(ListMetadata.DeserializeFromFile).ToList();

            // Get all files in the folder
            var files = Directory.GetFiles(filePath, $"*.{ListExtension}");

            if (addNewFiles || listsMetadata.Count == 0)
            {
                // Get list file names without a matching metadata file
                var newFiles =
                    files.Where(
                        file =>
                            listsMetadata.All(
                                listInfo =>
                                    Path.GetFileName(listInfo.Location.ToLower()) != Path.GetFileName(file.ToLower())))
                        .ToList();

                // Generate any new files
                foreach (var newFile in newFiles)
                {
                    var listMetadata = new ListMetadata
                    {
                        ListId = Guid.NewGuid().ToString(),
                        Name = Path.GetFileNameWithoutExtension(newFile),
                        Description = Path.GetFileNameWithoutExtension(newFile),
                        Location = Path.GetFileName(newFile),
                        Type = "rule",
                        Separator = "|",
                        UpdatedBy = "MaritzCX",
                        LastUpdated = DateTime.UtcNow
                    };

                    listMetadata.SerializeToFile(Path.ChangeExtension(newFile, ListMetaDataExtension));
                }
            }

            if (!removeMissingFiles) return;

            // Get metadata files without a matching list file
            var missingFiles =
                listsMetadata.Where(
                    listMetadata =>
                        files.Any(file => Path.GetFileName(file.ToLower()) != listMetadata.Location.ToLower()))
                    .ToList();

            // Remove missing files
            foreach (var missingFile in missingFiles)
            {
                File.Delete(Path.Combine(filePath, Path.ChangeExtension(missingFile.Location, ListMetaDataExtension)));
            }
        }
    }
}