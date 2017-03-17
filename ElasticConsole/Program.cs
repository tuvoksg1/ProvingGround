using System;
using System.Linq;
using ElasticConsole.Data;
using Elasticsearch.Net;
using Nest;

namespace ElasticConsole
{
    class Program
    {
        //private static readonly string _indexName = "blog_author_index";

        static void Main(string[] args)
        {
            var manager = new DataManager();
            manager.Run();

            //var local = new Uri("http://localhost:9200");
            //var settings = new ConnectionSettings(local).DefaultIndex(_indexName);
            //var elastic = new ElasticClient(settings);

            //var res = elastic.LowLevel.ClusterHealth<object>();

            //Console.WriteLine(res.SuccessOrKnownError);

            //CreateIndex(elastic);

            //TestIndex(elastic);

            //CreatBlogPostBatch(elastic);

            //CreateRandomBlogs(elastic);

            //QueryBlogs(elastic);

            //QueryMatchingBlogs(elastic);

            //CreateNestedBlogs(elastic);

            //QueryNestedBlogs(elastic);

            //FilterMissingProperties(elastic);

            //RunDynamicQuery(elastic);

            Console.ReadLine();
        }

        private static void RunDynamicQuery(IElasticClient elastic)
        {
            const string name = "John";
            const string surname = "Doe";
            
            Func<NestedQueryDescriptor<BlogPost>, NestedQueryDescriptor<BlogPost>> firstname = n => n
                .Path(p => p.Author)
                .Query(nq => nq
                    .Match(nqm => nqm.Field(p => p.Author.FirstName).Query(name).Lenient()));

            Func<NestedQueryDescriptor<BlogPost>, NestedQueryDescriptor<BlogPost>> lastname = n => n
                .Path(p => p.Author)
                .Query(nq => nq
                    .Match(nqm => nqm.Field(p => p.Author.LastName).Query(surname).Lenient()));

            Func<QueryContainerDescriptor<BlogPost>, QueryContainer> must;

            if (!string.IsNullOrEmpty(name))
            {
                must = m => m.Nested(n => firstname(n)) && m.Nested(n => lastname(n));
            }
            else
            {
                must = m => m.Nested(n => lastname(n));
            }

            Func<BoolQueryDescriptor<BlogPost>, BoolQueryDescriptor<BlogPost>> boolQuery = bq => bq.Must(m => must(m));

            Func<QueryContainerDescriptor<BlogPost>, QueryContainer> filter = f => f
                .Bool(b => b
                    .MustNot(m2 => m2
                        .Exists(p => p.Field(fd => fd.Body))));

            Func<QueryContainerDescriptor<BlogPost>, QueryContainer> query = q => q
                .Bool(b => boolQuery(b)
                    .Filter(f2 => filter(f2)));

            var dynamicResult = elastic.Search<BlogPost>(s => s.Query(query));

            Console.WriteLine(dynamicResult.ApiCall.Success);
            Console.WriteLine(dynamicResult.Hits.Count());

            foreach (var hit in dynamicResult.Hits)
            {
                Console.WriteLine(hit.Source);
            }
        }

        private static void FilterMissingProperties(IElasticClient elastic)
        {
            var missingResult = elastic.Search<BlogPost>(s => s
                .Query(fq => fq
                    .MatchAll())
                .Aggregations(f2 => f2.Missing("PostsWithNoBody", p => p.Field(f3 => f3.Body))));

            Console.WriteLine(missingResult.ApiCall.Success);
            Console.WriteLine(missingResult.Hits.Count());

            foreach (var hit in missingResult.Hits)
            {
                Console.WriteLine(hit.Source);
            }
        }

        private static void QueryNestedBlogs(ElasticClient elastic)
        {
            var nestedRes = elastic.Search<BlogPost>(s => s
                .Query(q => q
                    .Nested(n => n
                        .Path(b => b.Author)
                        .Query(nq =>
                            nq.Match(m1 => m1.Field(f1 => f1.Author.FirstName).Query("John")) &&
                            nq.Match(m2 => m2.Field(f2 => f2.Author.LastName).Query("Doe")))
                    )));

            Console.WriteLine(nestedRes.ApiCall.Success);
            Console.WriteLine(nestedRes.Hits.Count());

            foreach (var hit in nestedRes.Hits)
            {
                Console.WriteLine(hit.Source);
            }
        }

        private static void CreateNestedBlogs(IElasticClient elastic)
        {
            var author1 = new Author {Id = Guid.NewGuid(), FirstName = "John", LastName = "Doe"};
            var author2 = new Author {Id = Guid.NewGuid(), FirstName = "Notjohn", LastName = "Doe"};
            var author3 = new Author {Id = Guid.NewGuid(), FirstName = "John", LastName = "Notdoe"};

            var blogPosts = new[]
            {
                new BlogPost {Id = Guid.NewGuid(), Title = "test post 1", Body = "1", Author = author1},
                new BlogPost {Id = Guid.NewGuid(), Title = "test post 2", Body = "2", Author = author2},
                new BlogPost {Id = Guid.NewGuid(), Title = "test post 3", Body = "3", Author = author3}
            };

            foreach (var blogPost in blogPosts)
            {
                elastic.Index(blogPost, p => p
                    .Id(blogPost.Id.ToString())
                    .Refresh(new Refresh()));
            }

            //add blog with missing property
            var author4 = new Author
            {
                Id = Guid.NewGuid(),
                FirstName = "John",
                LastName = "Doe"
            };

            var blogPost1 = new BlogPost
            {
                Id = Guid.NewGuid(),
                Title = "test post 1",
                Body = null,
                Author = author4
            };

            elastic.Index(blogPost1, p => p
               .Id(blogPost1.Id.ToString())
               .Refresh(new Refresh()));

            Console.WriteLine("Nested blogs indexed");
        }

        private static void QueryMatchingBlogs(IElasticClient elastic)
        {
            var matchResult = elastic.Search<BlogPost>(s =>
                s.Query(q => q.Match(m =>
                    m.Field(f => f.Title)
                        .Query("test post 123")
                        .Operator(Operator.Or).
                        MinimumShouldMatch(MinimumShouldMatch.Fixed(1)))));

            Console.WriteLine(matchResult.ApiCall.Success);
            Console.WriteLine(matchResult.Hits.Count());

            foreach (var hit in matchResult.Hits)
            {
                Console.WriteLine(hit.Source);
            }
        }

        private static void QueryMatchingBlogs1(IElasticClient elastic)
        {
            var matchResult = elastic.Search<BlogPost>(s => s
                .Query(q => q
                    .Bool(b => b
                        .Must(m =>
                            m.Match(mt1 => mt1.Field(f1 => f1.Title).Query("title")) &&
                            m.Match(mt2 => mt2.Field(f2 => f2.Body).Query("001")))
                    )).Sort(o => o.Ascending(p => p.Title)));

            Console.WriteLine(matchResult.ApiCall.Success);
            Console.WriteLine(matchResult.Hits.Count());

            foreach (var hit in matchResult.Hits)
            {
                Console.WriteLine(hit.Source);
            }
        }

        private static void QueryMatchingBlogs2(IElasticClient elastic)
        {
            var matchResult = elastic.Search<BlogPost>(s => s
                .Query(q => q
                    .Bool(b => b
                        .Should(sh =>
                            sh.Match(mt1 => mt1.Field(f1 => f1.Title).Query("title")) ||
                            sh.Match(mt2 => mt2.Field(f2 => f2.Body).Query("001"))
                        ))).Sort(o => o.Ascending(p => p.Title)));

            Console.WriteLine(matchResult.ApiCall.Success);
            Console.WriteLine(matchResult.Hits.Count());

            foreach (var hit in matchResult.Hits)
            {
                Console.WriteLine(hit.Source);
            }
        }

        private static void QueryMatchingBlogs3(IElasticClient elastic)
        {
            var matchResult = elastic.Search<BlogPost>(s => s
                .Query(q => q
                    .Bool(b => b
                        .Should(sh =>
                            sh.Match(mt1 => mt1.Field(f1 => f1.Title).Query("title")) ||
                            sh.Match(mt2 => mt2.Field(f2 => f2.Title).Query("001")))
                        .Must(ms =>
                            ms.Match(mt2 => mt2.Field(f => f.Body).Query("this")))
                        .MustNot(mn =>
                            mn.Match(mt2 => mt2.Field(f => f.Body).Query("002"))
                        )))
                .Sort(o => o.Ascending(p => p.Title)));

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
                    .Refresh(new Refresh()));
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
                    .Refresh(new Refresh()));
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
                .Refresh(new Refresh()));

            Console.WriteLine(indexResult.ApiCall.Success);

            var resDel = elastic.Delete<BlogPost>(firstId.ToString());

            Console.WriteLine(resDel.ApiCall.Success);
        }

        private static void CreateIndex(IElasticClient elastic)
        {
            var result = elastic.CreateIndex(new IndexName
            {
                //Name = _indexName,
                Type = typeof (BlogPost)
            }, ci => ci
                //.Index(_indexName)
                .Mappings(ms => ms
                    .Map<BlogPost>(m => m.AutoMap())
                    .Map<Author>(m => m.AutoMap())
                ));

            Console.WriteLine(result.ApiCall.Success);
        }
    }
}
