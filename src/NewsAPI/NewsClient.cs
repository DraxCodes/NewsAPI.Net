using NewsAPI.Entities;
using NewsAPI.Entities.Enums;
using NewsAPI.Extensions;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Net;
using System.Net.Http;
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

        public async Task<NewsResult> FetchNewsAsync(EverythingRequest request)
        {
            var baseUrl = Constants.BaseUrl;
            var query = CreateUrl(request, baseUrl);

            var response = await SendRequestAsync(query);

            return GetResult(response);
        }

        public async Task<NewsResult> FetchNewsAsync(TopHeadlinesRequest request)
        {
            var baseUrl = Constants.BaseUrl;
            var query = CreateUrl(request, baseUrl);

            var response = await SendRequestAsync(query);

            return GetResult(response);
        }

        private string CreateUrl(EverythingRequest request, string url)
        {
            url += "everything?";
            url += $"q={request.Query}";
            url += FormattedDates(request);
            url += FormattedSorting(request.SortType);

            return url.ToString();
        }

        private string CreateUrl(TopHeadlinesRequest request, string url)
        {
            url += "top-headlines?";
            url += $"q={request.Query}";
            url += FormattedCountry(request.Country);
            url += FormattedCategory(request.Category);
            
            return url.ToString();
        }

        private string FormattedDates(EverythingRequest request)
        {
            string formattedDate = "";
            if (request.FromDate != null) { formattedDate += string.Format("&from={0:s}", request.FromDate); }
            if (request.ToDate != null) { formattedDate += string.Format("&to={0:s}", request.ToDate); }

            return formattedDate;
        }

        private string FormattedSorting(SortType sortType)
        {
            switch (sortType)
            {
                case SortType.Popularity:       return "&sortBy=popularity";
                case SortType.PublishedDate:    return "&sortBy=publishedAt";
                case SortType.Relevancy:        return "&sortBy=relevancy";

                default: throw new FormatException("Error parsing SortType");
            }
        }
        
        private string FormattedCountry(Country country)
            => country is Country.None 
                ? string.Empty 
                : $"&country={country.GetIsoAlpha2Code()}";

        private string FormattedCategory(NewsCategory category)
            => category is NewsCategory.None
                ? string.Empty 
                : $"&category={category.ToString().ToLowerInvariant()}";

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
