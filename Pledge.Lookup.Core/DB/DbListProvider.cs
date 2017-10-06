using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using Pledge.Common;
using Pledge.Common.Models;
using Pledge.Common.Models.Lookup;

namespace Pledge.Lookup.Core.DB
{
    public class DbListProvider : AbstractListProvider
    {
        private readonly IDbConnection _connection;

        public DbListProvider()
        {
            var connectionName = System.Configuration.ConfigurationManager.AppSettings[PledgeGlobal.ActiveConnection];
            var connectionString = System.Configuration.ConfigurationManager.ConnectionStrings[connectionName].ConnectionString;
            _connection = new SqlConnection(connectionString);
            Type = ListType.Database;
        }

        public override IEnumerable<List> GetLists(string tenantId)
        {
            const string commandText = "[Core].[ExternalListsGet]";
            var parameters = new Dictionary<string, object>
            {
                {"@tenantId", tenantId}
            };

            var result = _connection.Query<string>(commandText, parameters, null, true, null, CommandType.StoredProcedure).ToList();

            var lists = result.Select(arg => new List
            {
                Name = arg,
                Type = Type
            });
            return lists;
        }

        public override List<string> GetSingleColumnList(string listId, string name, string tenantId)
        {
            const string commandText = "[Core].[ExternalListGet]";

            var parameters = new Dictionary<string, object>
            {
                {"@listId", listId},
                {"@tenantId", tenantId}
            };

            var result = _connection.Query<string>(commandText, parameters, null, true, null, CommandType.StoredProcedure).ToList();
            return result;
        }

        public override void DeleteList(string listId, string tenantId)
        {
            const string commandText = "[Core].[ExternalListDelete]";

            var parameters = new Dictionary<string, object>
            {
                {"@listId", listId},
                {"@tenantId", tenantId}
            };

            _connection.Query(commandText, parameters, null, true, null, CommandType.StoredProcedure);
        }

        /// <summary>
        /// Get the id of the list from the supplied name.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="tenantId"></param>
        /// <returns></returns>
        public override string GetListId(string name, string tenantId)
        {
            const string commandText = "[Core].[ExternalListIdGet]";

            var parameters = new Dictionary<string, object>
            {
                {"@name", name},
                {"@tenantId", tenantId}
            };

            var result = _connection.Query<string>(commandText, parameters, null, true, null, CommandType.StoredProcedure).ToString();
            return result;
        }

        public override ListType Type { get; }

        public override void SaveList(List list)
        {
            const string commandText = "[Core].[SaveList]";

            var parameters = new Dictionary<string, object>
            {
                {"@listId", list.ListId},
                {"@name", list.Name },
                {"@function", list.Function },
                {"@tenantId", list.TenantId}
            };

            _connection.Execute(commandText, parameters, null, null, CommandType.StoredProcedure);
        }
    }
}
