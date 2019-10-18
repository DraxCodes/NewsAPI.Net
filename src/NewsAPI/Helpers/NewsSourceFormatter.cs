using NewsAPI.Entities.Enums;
using System;
using System.Text;

namespace NewsAPI.Helpers
{
    internal static class NewsSourceFormatter
    {
        internal static string FormatRequestSourceUrl(string sources, string baseUrl)
        {
            baseUrl += "top-headlines?sources=";
            baseUrl += sources;

            return baseUrl;
        }

        internal static string FormatNewsSource(NewsSource source)
        {
            switch (source)
            {
                case NewsSource.ABCNews:
                    return "abc-news";
                case NewsSource.ArsTechnica:
                    return "ars-technica";
                case NewsSource.AssociatedPress:
                    return "associated-press";
                case NewsSource.BBC:
                    return "bbc-news";
                case NewsSource.BBCSport:
                    return "bbc-sport";
                case NewsSource.BleacherReport:
                    return "bleacher-report";
                case NewsSource.Bloomberg:
                    return "bloomberg";
                case NewsSource.BusinessInsider:
                    return "business-insider";
                case NewsSource.BuzzFeed:
                    return "buzzfeed";
                case NewsSource.CBC:
                    return "cbc-news";
                case NewsSource.CBS:
                    return "cbs-news";
                case NewsSource.CNN:
                    return "cnn";
                case NewsSource.CryptoCoinsNews:
                    return "crypto-coin-news";
                case NewsSource.DailyMail:
                    return "daily-mail";
                case NewsSource.Engadget:
                    return "engadget";
                case NewsSource.EntertainmentWeekly:
                    return "entertainment-weekly";
                case NewsSource.ESPN:
                    return "espn";
                case NewsSource.Fortune:
                    return "fortune";
                case NewsSource.FoxNews:
                    return "fox-news";
                case NewsSource.FoxSports:
                    return "fox-sports";
                case NewsSource.GoogleNews:
                    return "google-news";
                case NewsSource.GoogleNewsUk:
                    return "google-news-uk";
                case NewsSource.HackerNews:
                    return "hacker-news";
                case NewsSource.IGN:
                    return "ign";
                case NewsSource.Independent:
                    return "independent";
                case NewsSource.Metro:
                    return "metro";
                case NewsSource.Mirror:
                    return "mirror";
                case NewsSource.MTV:
                    return "mtv-news";
                case NewsSource.NationalGeographic:
                    return "national-geographic";
                case NewsSource.NBC:
                    return "nbc-news";
                case NewsSource.NFL:
                    return "nfl-news";
                case NewsSource.NHL:
                    return "nhl-news";
                case NewsSource.Recode:
                    return "recode";
                case NewsSource.TechCrunch:
                    return "techcrunch";
                case NewsSource.TechRadar:
                    return "techradar";
                case NewsSource.TheLadBible:
                    return "the-lad-bible";
                case NewsSource.Verge:
                    return "the-verge";
                case NewsSource.Vice:
                    return "vice-news";
                case NewsSource.Wired:
                    return "wired";
                default:
                    throw new NotSupportedException("The entered type is not currently supported.");
            }
        }
        internal static string FormatNewsSources(NewsSource[] sources)
        {
            var sourceResultStringBuilder = new StringBuilder();
            foreach (var source in sources)
            {
                var formattedSource = FormatNewsSource(source);
                sourceResultStringBuilder.Append($"{formattedSource},");
            }

            return sourceResultStringBuilder.ToString();
        }
    }
}
