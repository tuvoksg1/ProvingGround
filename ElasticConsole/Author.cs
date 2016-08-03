using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nest;

namespace ElasticConsole
{
    [ElasticsearchType(Name = "author", IdProperty = "Id")]
    public class Author
    {
        [String(Index = FieldIndexOption.NotAnalyzed)]
        public Guid? Id { get; set; }

        [String(Name = "first_name", Index = FieldIndexOption.Analyzed)]
        public string FirstName { get; set; }

        [String(Name = "last_name", Index = FieldIndexOption.Analyzed)]
        public string LastName { get; set; }

        public override string ToString()
        {
            return $"Id: '{Id}', First name: '{FirstName}', Last Name: '{LastName}'";
        }
    }
}
