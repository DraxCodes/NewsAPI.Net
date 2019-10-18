using NewsAPI.Entities;
using NewsAPI.Entities.Enums;
using NewsAPI.Helpers;
using Newtonsoft.Json;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace NewsAPI
{
    public class NewsClient : INewsClient
    {
        private readonly HttpClient _httpClient;

        /// <summary>
        /// Create a new instance of the NewsClient.
        /// </summary>
        /// <param name="apiKey">Your API key from https://newsapi.org</param>
        public NewsClient(string apiKey)
        {
            _httpClient = new HttpClient(new HttpClientHandler { AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate });
            _httpClient.DefaultRequestHeaders.Add("user-agent", "NewsAPI.Net");
            _httpClient.DefaultRequestHeaders.Add("x-api-key", apiKey);
        }

        public async Task<NewsResult> FetchNewsAsync(AllNewsRequest request)
        {
            var baseUrl = Constants.BaseUrl;
            var query = RequestFormat.CreateUrl(request, baseUrl);

            var response = await SendRequestAsync(query);

            return GetResult(response);
        }

        public async Task<NewsResult> FetchNewsAsync(TopHeadlinesRequest request)
        {
            var baseUrl = Constants.BaseUrl;
            var query = RequestFormat.CreateUrl(request, baseUrl);

            var response = await SendRequestAsync(query);

            return GetResult(response);
        }

        public async Task<NewsResult> FetchNewsFromSource(NewsSource source)
        {
            var baseUrl = Constants.BaseUrl;
            var requestSource = NewsSourceFormatter.FormatNewsSource(source);
            var query = NewsSourceFormatter.FormatRequestSourceUrl(requestSource, baseUrl);

            var response = await SendRequestAsync(query);

            return GetResult(response);
        }

        public async Task<NewsResult> FetchNewsFromSource(NewsSource[] sources)
        {
            var baseUrl = Constants.BaseUrl;
            var requestSource = NewsSourceFormatter.FormatNewsSources(sources);
            var query = NewsSourceFormatter.FormatRequestSourceUrl(requestSource, baseUrl);

            var response = await SendRequestAsync(query);

            return GetResult(response);
        }

        //public Task<NewsResult> FetchNewsFromSource(string source)
        //{
        //    throw new System.NotImplementedException();
        //}

        private NewsResult GetResult(NewsResponse newsResponse)
        {
            var result = new NewsResult();

            if (newsResponse.Status != ResponseStatus.Ok)
            {
                result.Error = newsResponse.ErrorCode;
                return result;
            }

            result.Articles = newsResponse.NewsArticles;
            result.TotalResults = newsResponse.NewsArticles.Count();

            return result;
        }

        private async Task<NewsResponse> SendRequestAsync(string query)
        {
            var httpRequest = new HttpRequestMessage(HttpMethod.Get, query);
            var response = await _httpClient.SendAsync(httpRequest);

            var responseContent = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<NewsResponse>(responseContent);
        }
    }
}
