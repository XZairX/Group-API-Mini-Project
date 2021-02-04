using RestSharp;

namespace APIMiniProject
{
    public class WeatherMapBaseAPI
    {
        private readonly IRestClient _client;

        public WeatherMapBaseAPI()
        {
            _client = new RestClient(WeatherMapConfigReader.BaseUrl);
        }

        public IRestResponse Execute(RestRequest request)
        {
            return _client.Execute(request);
        }
    }
}
