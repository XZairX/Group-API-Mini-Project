using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIMiniProject
{
    public static class WeatherMapConfigReader
    {
        public static readonly string BaseUrl = ConfigurationManager.AppSettings["base_url"];
        public static readonly string ApiKey = ConfigurationManager.AppSettings["api_key"];
        public static readonly string ApiUriMod = ConfigurationManager.AppSettings["access_key_url_mod"];
    }
}
