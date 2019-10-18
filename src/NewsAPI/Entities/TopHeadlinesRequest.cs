using NewsAPI.Entities.Enums;

namespace NewsAPI.Entities
{
    public class TopHeadlinesRequest : IRequest
    {
        public string Query { get; private set; }
        public Country Country { get; private set; }
        public NewsCategory Category { get; private set; }

        /// <summary>
        /// Creates an all news request entity which is used in <see cref="NewsClient.FetchNewsAsync(TopHeadlinesRequest)"/>.
        /// </summary>
        /// <param name="query">The search query.</param>
        public TopHeadlinesRequest(string query)
        {
            Query = query;
        }

        /// <summary>
        /// Creates an all news request entity which is used in <see cref="NewsClient.FetchNewsAsync(TopHeadlinesRequest)"/>.
        /// </summary>
        /// <param name="query">The search query.</param>
        /// <param name="country">The country you wish to find results for. Example: <see cref="Country.Australia"/>.</param>
        public TopHeadlinesRequest(string query, Country country)
        {
            Query = query;
            Country = country;
        }

        /// <summary>
        /// Creates an all news request entity which is used in <see cref="NewsClient.FetchNewsAsync(TopHeadlinesRequest)"/>.
        /// </summary>
        /// <param name="query">The search query.</param>
        /// <param name="category">The category you wish to search. Example: <see cref="NewsCategory.Technology"/>.</param>
        public TopHeadlinesRequest(string query, NewsCategory category)
        {
            Query = query;
            Category = category;
        }

        /// <summary>
        /// Creates an all news request entity which is used in <see cref="NewsClient.FetchNewsAsync(TopHeadlinesRequest)"/>.
        /// </summary>
        /// <param name="query">The search query.</param>
        /// <param name="country">The country you wish to find results for. Example: <see cref="Country.Australia"/>.</param>
        /// <param name="category">The category you wish to search. Example: <see cref="NewsCategory.Technology"/>.</param>
        public TopHeadlinesRequest(string query, Country country, NewsCategory category)
        {
            Query = query;
            Country = country;
            Category = category;
        }
    }
}
