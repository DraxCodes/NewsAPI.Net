using NewsAPI.Entities.Enums;
using System;

namespace NewsAPI.Entities
{
    /// <summary>
    /// An all news request entity.
    /// </summary>
    public class AllNewsRequest : IRequest
    {
        /// <summary>
        /// The search query.
        /// </summary>
        public string Query { get; private set; }

        /// <summary>
        /// The oldest date an article can have.
        /// </summary>
        public DateTime? FromDate { get; private set; }

        /// <summary>
        /// The newest date an article can have.
        /// </summary>
        public DateTime? ToDate { get; private set; }

        /// <summary>
        /// How you want to sort the results.
        /// </summary>
        public SortType SortType { get; private set; }

        /// <summary>
        /// Creates an all news request entity which is used in <see cref="NewsClient.FetchNewsAsync(AllNewsRequest)"/>.
        /// </summary>
        /// <param name="query">The search query.</param>
        /// <param name="sortType">How you want to sort the results.</param>
        public AllNewsRequest(string query, SortType sortType)
        {
            Query = query;
            SortType = sortType;
        }

        /// <summary>
        /// Creates an all news request entity which is used in <see cref="NewsClient.FetchNewsAsync(AllNewsRequest)"/>.
        /// </summary>
        /// <param name="query">The search query.</param>
        /// <param name="sortType">How you want to sort the results.</param>
        /// <param name="fromDate">The oldest date an article can have.</param>
        public AllNewsRequest(string query, SortType sortType, DateTime fromDate)
        {
            Query = query;
            SortType = sortType;
            FromDate = fromDate;
        }

        /// <summary>
        /// Creates an all news request entity which is used in <see cref="NewsClient.FetchNewsAsync(AllNewsRequest)"/>.
        /// </summary>
        /// <param name="query">The search query.</param>
        /// <param name="sortType">How you want to sort the results.</param>
        /// <param name="fromDate">The oldest date an article can have.</param>
        /// <param name="toDate">The newest date an article can have.</param>
        public AllNewsRequest(string query, SortType sortType, DateTime fromDate, DateTime toDate)
        {
            Query = query;
            SortType = sortType;
            FromDate = fromDate;
            ToDate = toDate;
        }
    }
}
