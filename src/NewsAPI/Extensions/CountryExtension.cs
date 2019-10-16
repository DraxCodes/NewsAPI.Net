using NewsAPI.Entities.Enums;

namespace NewsAPI.Extensions
{
    public static class CountryExtension
    {
        /// <summary>
        /// Get the 2-letter ISO 3166-1 code for the <paramref name="country"/>.
        /// See https://www.iso.org/obp/.
        /// </summary>
        public static string GetIsoAlpha2Code(this Country country)
        {
            switch (country)
            {
                case Country.UnitedArabEmirates:    return "ae";
                case Country.Argentina:             return "ar";
                case Country.Austria:               return "at";
                case Country.Australia:             return "au";
                case Country.Belgium:               return "be";
                case Country.Bulgaria:              return "bg";
                case Country.Brazil:                return "br";
                case Country.Canada:                return "ca";
                case Country.Switzerland:           return "ch";
                case Country.China:                 return "cn";
                case Country.Colombia:              return "co";
                case Country.Cuba:                  return "cu";
                case Country.CzechRepublic:         return "cz";
                case Country.Germany:               return "de";
                case Country.Egypt:                 return "eg";
                case Country.France:                return "fr";
                case Country.GreatBritain:          return "gb";
                case Country.Greece:                return "gr";
                case Country.HongKong:              return "hk";
                case Country.Hungary:               return "hu";
                case Country.Indonesia:             return "id";
                case Country.Ireland:               return "ie";
                case Country.Israel:                return "il";
                case Country.India:                 return "in";
                case Country.Italy:                 return "it";
                case Country.Japan:                 return "jp";
                case Country.Korea:                 return "kr";
                case Country.Lithuania:             return "lt";
                case Country.Latvia:                return "lv";
                case Country.Morocco:               return "ma";
                case Country.Mexico:                return "mx";
                case Country.Malaysia:              return "my";
                case Country.Nigeria:               return "ng";
                case Country.Netherlands:           return "nl";
                case Country.Norway:                return "no";
                case Country.NewZealand:            return "nz";
                case Country.Philippines:           return "ph";
                case Country.Poland:                return "pl";
                case Country.Portugal:              return "pt";
                case Country.Romania:               return "ro";
                case Country.Serbia:                return "rs";
                case Country.Russia:                return "ru";
                case Country.SaudiArabia:           return "sa";
                case Country.Sweden:                return "se";
                case Country.Singapore:             return "sg";
                case Country.Slovenia:              return "si";
                case Country.Slovakia:              return "sk";
                case Country.Thailand:              return "th";
                case Country.Turkey:                return "tr";
                case Country.Taiwan:                return "tw";
                case Country.Ukraine:               return "ua";
                case Country.UnitedStatesOfAmerica: return "us";
                case Country.Venezuela:             return "ve";
                case Country.SouthAfrica:           return "za";

                default: throw new System.ArgumentException("This country is invalid");
            }
        }
    }
}
