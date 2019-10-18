using NewsAPI.Entities.Enums;

namespace NewsAPI.Entities
{
    public class TopHeadlinesRequest : IRequest
    {
        public string Query { get; private set; }
        public Country Country { get; private set; }
        public NewsCategory Category { get; private set; }

        public TopHeadlinesRequest(string query)
        {
            Query = query;
        }

        public TopHeadlinesRequest(string query, Country country)
        {
            Query = query;
            Country = country;
        }

        public TopHeadlinesRequest(string query, NewsCategory category)
        {
            Query = query;
            Category = category;
        }

        public TopHeadlinesRequest(string query, Country country, NewsCategory category)
        {
            Query = query;
            Country = country;
            Category = category;
        }
    }
}
