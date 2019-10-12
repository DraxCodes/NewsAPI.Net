using NewsAPI.Entities.Enums;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace NewsAPI.Entities
{
    public sealed class NewsResponse
    {
        public ResponseStatus Status { get; set; }
        
        public ErrorType? ErrorCode { get; set; }
        
        public string Message { get; set; }
        
        [JsonProperty("articles")]
        public IEnumerable<NewsArticle> NewsArticles { get; set; }
        
        public int TotalResults { get; set; }
    }
}
