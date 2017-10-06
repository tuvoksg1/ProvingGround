using System;
using System.Collections.Generic;
using Pledge.Common.Interfaces;

namespace Pledge.Common.Models
{
    /// <summary>
    /// Base configuration class
    /// </summary>
    public class BaseConfiguration : InfoSerializer<BaseConfiguration>, IConfiguration
    {
        /// <summary>
        /// Identifier property
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets the version identifier.
        /// </summary>
        public int VersionId { get; set; }

        /// <summary>
        /// Configuration Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Configuration description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Configuration author
        /// </summary>
        public string Author { get; set; }

        /// <summary>
        /// Gets the group identifier.
        /// </summary>
        public string GroupId { get; set; }

        /// <summary>
        /// Gets the group name.
        /// </summary>
        public string GroupName { get; set; }

        /// <summary>
        /// The document property
        /// </summary>
        public BaseDocument Model { get; set; }

        /// <summary>
        /// Property to store the List of rules in this configuration
        /// </summary>
        public List<PledgeRule> Rules { get; set; }

        /// <summary>
        /// Creates a copy from the specified original.
        /// </summary>
        /// <param name="original">The original.</param>
        /// <returns>A copy configuration</returns>
        public static BaseConfiguration Copy(IConfiguration original)
        {
            if (original == null)
            {
                return null;
            }

            return new BaseConfiguration
            {
                Id = Guid.NewGuid(),
                Name = $"Copy of {original.Name}",
                Description = original.Description,
                Model = original.Model,
                Rules = original.Rules
            };
        }
    }
}
