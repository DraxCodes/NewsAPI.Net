using NewsAPI.Entities;
using System.Threading.Tasks;

namespace NewsAPI
{
    public interface INewsClient
    {
        Task<NewsResult> FetchNewsAsync(AllNewsRequest request);
        Task<NewsResult> FetchNewsAsync(TopHeadlinesRequest request);
    }
}