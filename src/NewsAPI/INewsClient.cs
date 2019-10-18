using NewsAPI.Entities;
using NewsAPI.Entities.Enums;
using System.Threading.Tasks;

namespace NewsAPI
{
    public interface INewsClient
    {
        Task<NewsResult> FetchNewsAsync(AllNewsRequest request);
        Task<NewsResult> FetchNewsAsync(TopHeadlinesRequest request);
        Task<NewsResult> FetchNewsFromSource(NewsSource source);
        //Task<NewsResult> FetchNewsFromSource(string source);
    }
}