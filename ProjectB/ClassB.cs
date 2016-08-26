using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using ProjectC;

namespace ProjectB
{
    public class ClassB : ClassC
    {
        private readonly IDbConnection _connection;

        public ClassB(IDbConnection connection)
        {
            _connection = connection;
        }

        public int Delete(string userId)
        {
            const string commandText = "[Security].[UserLoginDeleteById]";
            var parameters = new Dictionary<string, object>
            {
                {"@userId", userId}
            };

            return _connection.Execute(commandText, parameters, null, null, CommandType.StoredProcedure);
        }

        public List<string> FindByUserId(string userId)
        {
            const string commandText = "[Security].[UserRoleGetById]";
            var parameters = new Dictionary<string, object>
            {
                {"@userId", userId}
            };

            var result = _connection.Query<string>(commandText, parameters, null, true, null, CommandType.StoredProcedure);

            return result.ToList();
        }
    }
}
