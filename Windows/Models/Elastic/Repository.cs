using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using Newtonsoft.Json;

namespace Windows.Models.Elastic
{
    public class Repository
    {
        private readonly IDbConnection _connection;

        public Repository()
        {
            const string connectionString = "Data Source=.;Initial Catalog=MR_UK_Pledge;Integrated Security=True";
            _connection = new SqlConnection(connectionString);
        }

        //public string GetAuditLogs(string author)
        //{
        //    const string commandText = "[Core].[AuditLogGet]";

        //    var parameters = new Dictionary<string, object>
        //    {
        //        {"@author", author}
        //    };

        //    var result = _connection.Query(commandText, parameters, null, true, null, CommandType.StoredProcedure).ToList();
        //    return JsonConvert.SerializeObject(result);
        //}

        public IEnumerable<LogEntry> GetAuditLogs()
        {
            const string commandText = "[Core].[AuditLogFetch]";

            var result = _connection.Query<LogEntry>(commandText, null, null, true, null, CommandType.StoredProcedure).ToList();
            return result;
        }
    }
}
