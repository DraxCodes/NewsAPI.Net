using NewsAPI.Entities;
using NewsAPI.Entities.Enums;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace NewsAPI.XUnitTests
{
    public class ClientTests
    {
        private readonly INewsClient _newsClient;

        public ClientTests()
        {
            _newsClient = new NewsClient("");
        }

        [Fact]
        public async Task NewsResponse_EverythingRequest_NotNull()
        {
            var request = new AllNewsRequest("Arrow", SortType.PublishedDate);
            var result = await _newsClient.FetchNewsAsync(request);

            foreach (var article in result.Articles)
            {
                Console.WriteLine(article.Title);
                Console.WriteLine(article.Description);
                Console.WriteLine(article.Author);
                Console.WriteLine(article.Source.Name);
            }

            Assert.Equal(ResponseStatus.Ok, result.ResponseStatus);
            Assert.NotNull(result.Articles);
        }

        [Fact]
        public async Task NewsResponse_TopHeadlinesRequest_NotNull()
        {
            var request = new TopHeadlinesRequest("AI", NewsCategory.Technology);
            var result = await _newsClient.FetchNewsAsync(request);

            foreach (var article in result.Articles)
            {
                Console.WriteLine(article.Title);
                Console.WriteLine(article.Description);
                Console.WriteLine(article.Author);
                Console.WriteLine(article.Source.Name);
            }

            Assert.Equal(ResponseStatus.Ok, result.ResponseStatus);
            Assert.NotNull(result.Articles);
        }

        [Fact]
        public async Task NewsResponse_FetchTopNewsFromSource()
        {
            var result = await _newsClient.FetchNewsFromSource(NewsSource.BBC);

            bool hasBBCNewsSource = result.Articles.Any(a => a.Source.Name == "BBC News");

            Assert.Equal(ResponseStatus.Ok, result.ResponseStatus);
            Assert.NotNull(result.Articles);
            Assert.True(hasBBCNewsSource);
        }

        [Fact]
        public async Task NewsResponse_FetchTopNewsFromSources()
        {
            var sources = new NewsSource[] 
            { 
                NewsSource.ABCNews,
                NewsSource.BBC
            };

            var result = await _newsClient.FetchNewsFromSource(sources);

            bool hasABCNewsSource = result.Articles.Any(a => a.Source.Name == "ABC News");
            bool hasBBCNewsSource = result.Articles.Any(a => a.Source.Name == "BBC News");

            Assert.Equal(ResponseStatus.Ok, result.ResponseStatus);
            Assert.NotNull(result.Articles);
            Assert.True(hasABCNewsSource);
            Assert.True(hasBBCNewsSource);
        }
    }
}
