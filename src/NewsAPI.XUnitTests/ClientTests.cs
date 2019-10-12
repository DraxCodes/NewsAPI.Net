using NewsAPI.Entities;
using NewsAPI.Entities.Enums;
using System.Threading.Tasks;
using Xunit;

namespace NewsAPI.XUnitTests
{
    public class ClientTests
    {
        private readonly NewsClient _newsClient;

        public ClientTests()
        {
            _newsClient = new NewsClient("364365705e724fc9a5f385b9e24f487e");
        }

        [Fact]
        public async Task NewsResponse_NotNull()
        {
            var request = new NewsRequest(RequestType.Everything, "apple", SortType.Popularity);
            var result = await _newsClient.FetchNews(request);

            Assert.Equal(StatusType.Ok, result.Status);
            Assert.NotNull(result.NewsArticles);
        }
    }
}
