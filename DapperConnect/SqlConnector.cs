using System;
using System.Data.SqlClient;
using System.Linq;
using Dapper;

namespace DapperConnect
{
    public class SqlConnector
    {
        private readonly SqlConnection _connection;
        //private const string ConnectionString = "Server=tcp: AGL_TST_ReedOnline.ree-test.local,60100; DATABASE=Reed Online; User ID=MondayLoveAppB; PASSWORD=MLm868rIl26IT3pdjrKERgh;";
        private const string ConnectionString = "SERVER=AGL_TST_ReedOnline.ree-test.local,60100; DATABASE=Reed Online; User ID=MondayLoveAppB; PASSWORD=MLm868rIl26IT3pdjrKERgh;Connection Timeout=300;Application Name=JobSyncService;";
        private const string SelectQuery = "SELECT * FROM JobTaxonomy WHERE JobId = 28440598";

        public SqlConnector()
        {
            _connection = new SqlConnection(ConnectionString);
        }

        public void RunQuery()
        {
            _connection.Open();

            using (_connection)
            {
                var results = _connection.Query<dynamic>(SelectQuery);

                if(results.Count() == 0)
                {
                    Console.WriteLine($"No Data found");
                }

                foreach(var result in results)
                {
                    Console.WriteLine($"{result}");
                }
            }
        }
    }
}
