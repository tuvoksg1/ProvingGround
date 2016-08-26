using System.Data.SqlClient;
using ProjectB;

namespace ProjectA
{
    public class ClassA
    {
        private ClassB _classB;

        public ClassA(string connectionString)
        {
            _classB = new ClassB(new SqlConnection(connectionString));
        }
    }
}
