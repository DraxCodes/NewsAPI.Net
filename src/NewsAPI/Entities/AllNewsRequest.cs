using NewsAPI.Entities.Enums;
using System;

namespace NewsAPI.Entities
{
    public class AllNewsRequest : IRequest
    {
        public string Query { get; private set; }
        public DateTime? FromDate { get; private set; }
        public DateTime? ToDate { get; private set; }
        public SortType SortType { get; private set; }

        public AllNewsRequest(string query, SortType sortType)
        {
            Query = query;
            SortType = sortType;
        }

        public AllNewsRequest(string query, SortType sortType, DateTime fromDate)
        {
            Query = query;
            SortType = sortType;
            FromDate = fromDate;
        }

        public AllNewsRequest(string query, SortType sortType, DateTime fromDate, DateTime toDate)
        {
            Query = query;
            SortType = sortType;
            FromDate = fromDate;
            ToDate = toDate;
        }
    }
}
