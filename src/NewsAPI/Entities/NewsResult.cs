using NewsAPI.Entities.Enums;
using System.Collections.Generic;

namespace NewsAPI.Entities
{
    public class NewsResult
    {
        public ResponseStatus ResponseStatus { get; set; }
        public ErrorType? Error { get; set; }
        public int TotalResults { get; set; }
        public IEnumerable<NewsArticle> Articles { get; set; }
    }
}
