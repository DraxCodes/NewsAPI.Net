using NewsAPI.Entities;
using NewsAPI.Entities.Enums;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace NewsAPI
{
    public class NewsClient
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

        public async Task<NewsResponse> FetchNews(NewsRequest request)
        {
            var query = CreateQueryFromRequest(request);
            return await SendRequest(query);
        }

        private string CreateQueryFromRequest(NewsRequest request)
        {
            var url = Constants.BaseUrl;

            switch (request.RequestType)
            {
                case RequestType.Everything:
                    return CreateAllNewsUrl(request, url);
                case RequestType.TopHeadline:
                    return CreateTopHeadlinesUrl(request, url);
                default:
                    throw new FormatException("Error parsing NewsRequest");
            }
        }

        private string CreateAllNewsUrl(NewsRequest request, string url)
        {
            url += "everything?";
            url += $"q={request.Query}";
            url += FormattedDates(request);
            url += FormattedSorting(request.SortType);

            return url.ToString();
        }

        private string CreateTopHeadlinesUrl(NewsRequest request, string url)
        {
            url += "top-headlines?";


            return url.ToString();
        }

        private string FormattedDates(NewsRequest request)
        {
            string formattedDate = "";
            if (request.FromDate != null) { formattedDate += string.Format("&from={0:s}", request.FromDate); }
            if (request.ToDate != null) { formattedDate += string.Format("&to={0:s}", request.ToDate); }

            return formattedDate;
        }

        private string FormattedSorting(SortType sortType)
        {
            string formattedSort = "&sortBy=";

            switch (sortType)
            {
                case SortType.Popularity:
                    formattedSort += "popularity";
                    break;
                case SortType.PublishedDate:
                    formattedSort += "publishedAt";
                    break;
                case SortType.Relevancy:
                    formattedSort += "relevancy";
                    break;
                default:
                    throw new FormatException("Error parsing SortType");
            }

            return formattedSort;
        }

        private async Task<NewsResponse> SendRequest(string query)
        {
            var httpRequest = new HttpRequestMessage(HttpMethod.Get, query);
            var response = await _httpClient.SendAsync(httpRequest);

            var responseContent = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<NewsResponse>(responseContent);
        }
    }
}
