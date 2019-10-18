using NewsAPI.Entities;
using NewsAPI.Entities.Enums;
using NewsAPI.Extensions;
using System;

namespace NewsAPI.Helpers
{
    internal static class RequestFormat
    {
        internal static string CreateUrl(AllNewsRequest request, string baseUrl)
        {
            baseUrl += "everything?";
            baseUrl += $"q={request.Query}";
            baseUrl += FormattedDates(request);
            baseUrl += FormattedSorting(request.SortType);

            return baseUrl.ToString();
        }

        internal static string CreateUrl(TopHeadlinesRequest request, string url)
        {
            url += "top-headlines?";
            url += $"q={request.Query}";
            url += FormattedCountry(request.Country);
            url += FormattedCategory(request.Category);

            return url.ToString();
        }

        private static string FormattedDates(AllNewsRequest request)
        {
            string formattedDate = "";
            if (request.FromDate != null) { formattedDate += string.Format("&from={0:s}", request.FromDate); }
            if (request.ToDate != null) { formattedDate += string.Format("&to={0:s}", request.ToDate); }

            return formattedDate;
        }

        private static string FormattedSorting(SortType sortType)
        {
            switch (sortType)
            {
                case SortType.Popularity: return "&sortBy=popularity";
                case SortType.PublishedDate: return "&sortBy=publishedAt";
                case SortType.Relevancy: return "&sortBy=relevancy";

                default: throw new FormatException("Error parsing SortType");
            }
        }

        private static string FormattedCountry(Country country)
            => country is Country.None
                ? string.Empty
                : $"&country={country.GetIsoAlpha2Code()}";

        private static string FormattedCategory(NewsCategory category)
            => category is NewsCategory.None
                ? string.Empty
                : $"&category={category.ToString().ToLowerInvariant()}";
    }
}
