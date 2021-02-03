using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIMiniProject.HTTPManager
{
    public class LatestWeatherMapCallManager : WeatherMapBaseAPI
    {
        public string GetResponse()
        {
            var request = new RestRequest("/weather" + "appid" + WeatherMapConfigReader.ApiKey);
            var response = Execute(request, Method.GET);
            return response.Content;
        }
    }
}
