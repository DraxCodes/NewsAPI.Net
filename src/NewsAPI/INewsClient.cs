using NewsAPI.Entities;
using NewsAPI.Entities.Enums;
using System.Threading.Tasks;

namespace NewsAPI
{
    public interface INewsClient
    {
        /// <summary>
        /// Fetch News from the API.
        /// </summary>
        /// <param name="request">Returns news from all sources for an entered request.</param>
        /// <returns><see cref="NewsResult"/> The result of the search with an IEnumerable collection of articles.</returns>
        Task<NewsResult> FetchNewsAsync(AllNewsRequest request);

        /// <summary>
        /// Fetch News from the API.
        /// </summary>
        /// <param name="request">Returns the top headlines from all sources for an entered request.</param>
        /// <returns><see cref="NewsResult"/> The result of the search with an IEnumerable collection of articles.</returns>
        Task<NewsResult> FetchNewsAsync(TopHeadlinesRequest request);

        /// <summary>
        /// Fetch News from a specific source.
        /// </summary>
        /// <param name="source">The source you want to request news for.</param>
        /// <returns><see cref="NewsResult"/> The result of the search with an IEnumerable collection of articles.</returns>
        Task<NewsResult> FetchNewsFromSource(NewsSource source);

        /// <summary>
        /// Fetch News from a specific source.
        /// </summary>
        /// <param name="sources">The sources you want to request news for.</param>
        /// <returns><see cref="NewsResult"/> The result of the search with an IEnumerable collection of articles.</returns>
        Task<NewsResult> FetchNewsFromSource(NewsSource[] sources);

        /// <summary>
        /// Fetch News from a specific source.
        /// </summary>
        /// <param name="source">The source you want to request news for. (comma seperated)</param>
        /// <returns><see cref="NewsResult"/> The result of the search with an IEnumerable collection of articles.</returns>
        /// <exception cref="System.NotSupportedException">Throws for an invalid source.</exception>
        Task<NewsResult> FetchNewsFromSource(string source);
    }
}