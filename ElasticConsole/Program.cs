using System;
using System.Linq;
using Elasticsearch.Net;
using Nest;

namespace ElasticConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var local = new Uri("http://localhost:9200");
            var settings = new ConnectionSettings(local).DefaultIndex("blog_post_index");
            var elastic = new ElasticClient(settings);

            var res = elastic.LowLevel.ClusterHealth<object>();

            Console.WriteLine(res.SuccessOrKnownError);

            //CreateIndex(elastic);

            //TestIndex(elastic);

            //CreatBlogPostBatch(elastic);

            //CreateRandomBlogs(elastic);

            //QueryBlogs(elastic);

            QueryMatchingBlogs(elastic);

            Console.ReadLine();
        }

        private static void QueryMatchingBlogs(IElasticClient elastic)
        {
            var matchResult = elastic.Search<BlogPost>(s =>
                s.Query(q => q.Match(m =>
                    m.Field(f => f.Title)
                        .Query("test post 123"))));

            Console.WriteLine(matchResult.ApiCall.Success);
            Console.WriteLine(matchResult.Hits.Count());

            foreach (var hit in matchResult.Hits)
            {
                Console.WriteLine(hit.Source);
            }
        }

        private static void CreateRandomBlogs(IElasticClient elastic)
        {
            var blogPosts = new[]
            {
                new BlogPost {Id = Guid.NewGuid(), Title = "test post 123", Body = "1"},
                new BlogPost {Id = Guid.NewGuid(), Title = "test something 123", Body = "2"},
                new BlogPost {Id = Guid.NewGuid(), Title = "read this post", Body = "3"},
                new BlogPost {Id = Guid.NewGuid(), Title = "read my blog", Body = "4"},
                new BlogPost {Id = Guid.NewGuid(), Title = "post from jason", Body = "5"},
                new BlogPost {Id = Guid.NewGuid(), Title = "private blog", Body = "6"}
            };

            foreach (var blogPost in blogPosts)
            {
                elastic.Index(blogPost, p => p
                    .Id(blogPost.Id.ToString())
                    .Refresh());
            }
        }

        private static void QueryBlogs(IElasticClient elastic)
        {
            var result = elastic.Search<BlogPost>(s => s
                .From(0)
                .Size(20)
                .Query(q => q.MatchAll())
                .Sort(o => o.Ascending(p => p.Title)));

            Console.WriteLine(result.ApiCall.Success);
            Console.WriteLine(result.Hits.Count());

            foreach (var hit in result.Hits)
            {
                Console.WriteLine(hit.Source);
            }
        }

        private static void CreatBlogPostBatch(IElasticClient elastic)
        {
            for (var index = 0; index < 10; index++)
            {
                var blogPost = new BlogPost
                {
                    Id = Guid.NewGuid(),
                    Title = $"title {index:000}",
                    Body = $"This is {index:000} very long blog post!"
                };
                elastic.Index(blogPost, p => p
                    .Id(blogPost.Id.ToString())
                    .Refresh());
            }
        }

        private static void TestIndex(IElasticClient elastic)
        {
            var blogPost = new BlogPost
            {
                Id = Guid.NewGuid(),
                Title = "First blog post",
                Body = "This is very long blog post!"
            };

            var firstId = blogPost.Id;

            var indexResult = elastic.Index(blogPost, p => p
                .Id(blogPost.Id.ToString())
                .Refresh());

            Console.WriteLine(indexResult.ApiCall.Success);

            var resDel = elastic.Delete<BlogPost>(firstId.ToString());

            Console.WriteLine(resDel.ApiCall.Success);
        }

        private static void CreateIndex(IElasticClient elastic)
        {
            var result = elastic.CreateIndex(new IndexName
            {
                Name = "blog_post_index",
                Type = typeof (BlogPost)
            });

            Console.WriteLine(result.ApiCall.Success);
        }
    }
}
