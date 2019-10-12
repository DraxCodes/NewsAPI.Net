using NewsAPI.Entities.Enums;
using System;

namespace NewsAPI.Entities
{
    public class NewsRequest
    {
        public RequestType RequestType { get; private set; }
        public string Query { get; private set; }
        public DateTime? FromDate { get; private set; }
        public DateTime? ToDate { get; private set; }
        public SortType SortType { get; private set; }

        public NewsRequest(RequestType requestType, string query, SortType sortType)
        {
            RequestType = RequestType;
            Query = query;
            SortType = sortType;
        }

        public NewsRequest(RequestType requestType, string query, SortType sortType, DateTime fromDate)
        {
            RequestType = RequestType;
            Query = query;
            SortType = sortType;
            FromDate = fromDate;
        }

        public NewsRequest(RequestType requestType, string query, SortType sortType, DateTime fromDate, DateTime toDate)
        {
            RequestType = RequestType;
            Query = query;
            SortType = sortType;
            FromDate = fromDate;
            ToDate = toDate;
        }

    }
}
