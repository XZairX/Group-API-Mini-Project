using RestSharp;

namespace APIMiniProject.HTTPManager
{
    public class LatestWeatherMapCallManager : WeatherMapBaseAPI
    {
        public string GetResponseByCityID(int id)
        {
            var request = new RestRequest("/weather");
            request.AddParameter("id", id); 
            return FinishRequest(request);
        }

        public string GetResponseByCityName(string name)
        {
            var request = new RestRequest("/weather");
            request.AddParameter("q", name);
            return FinishRequest(request);
        }

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

        public string GetResponseByLongAndLat(float latitude, float longitude)
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

        private string FinishRequest(RestRequest request)
		{
            request.AddParameter("appid", WeatherMapConfigReader.ApiKey);
            var response = Execute(request);
            return response.Content;    
        }
    }
}
