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

        // OLLY
        public string GetResponseByCityID(int id)
        {
            var request = new RestRequest("/weather");
            request.AddParameter("id", id); 
            return FinishRequest(request);
        }

        // RIAZ
        public string GetResponseByCityName(string name)
        {
            var request = new RestRequest("/weather");
            request.AddParameter("q", name);
            return FinishRequest(request);
        }

        // RIAZ
        public string GetResponseByCityNameState(string name, string stateCode)
        {
            var request = new RestRequest("/weather");
            request.AddParameter("q", $"{name},{stateCode}");
            return FinishRequest(request);
        }

        public string GetResponseByCityNameStateCountry(string name, string stateCode, string countryCode)
        {
            var request = new RestRequest("/weather");
            request.AddParameter("q", $"{name},{stateCode},{countryCode}");
            return FinishRequest(request);
        }

        // ALEX
        public string GetResponseByLongAndLat(double longitude, double latitude)
        {
            var request = new RestRequest("/weather");
            request.AddParameter("lat", latitude);
            request.AddParameter("lon", longitude);
            return FinishRequest(request);
        }

        public string GetResponseByZip(int zip, string countryCode)
        {
            var request = new RestRequest("/weather");
            request.AddParameter("zip", $"{zip},{countryCode}");
            return FinishRequest(request);
        }

        public string FinishRequest(RestRequest request)
		{
            request.AddParameter("appid", WeatherMapConfigReader.ApiKey);
            var response = Execute(request, Method.GET);
            return response.Content;
           
        }
    }
}
