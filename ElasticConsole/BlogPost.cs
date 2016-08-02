using System;
using Nest;

namespace ElasticConsole
{
    [ElasticsearchType(IdProperty = "Id", Name = "blog_post")]
    public class BlogPost
    {
        [String(Index = FieldIndexOption.NotAnalyzed)]
        public Guid? Id { get; set; }

        [String(Name = "title", Index = FieldIndexOption.Analyzed)]
        public string Title { get; set; }

        [String(Name = "body", Index = FieldIndexOption.Analyzed)]
        public string Body { get; set; }

        [Nested(Name = "author", IncludeInParent = true)]
        public Author Author { get; set; }

        public override string ToString()
        {
            return $"Id: '{Id}', Title: '{Title}', Body: '{Body}'";
        }
    }
}
