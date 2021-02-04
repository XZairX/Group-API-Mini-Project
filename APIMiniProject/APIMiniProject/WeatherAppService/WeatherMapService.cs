using APIMiniProject.DataHandling;
using APIMiniProject.HTTPManager;

namespace APIMiniProject
{
    public class WeatherMapService
    {
        public LatestWeatherMapCallManager CallManager { get; set; } = new LatestWeatherMapCallManager();
        public LatestWeatherMapDTO DTO { get; set; } = new LatestWeatherMapDTO();

        public string WeatherResponse { get; set; }

        public WeatherMapService(int id)
        {
            WeatherResponse = CallManager.GetResponseByCityID(id);
            DTO.DeserializeRates(WeatherResponse);
        }

        public WeatherMapService(string name)
        {
            WeatherResponse = CallManager.GetResponseByCityName(name);
            DTO.DeserializeRates(WeatherResponse);
        }

        public WeatherMapService(string name, string stateCode)
        {
            WeatherResponse = CallManager.GetResponseByCityNameState(name, stateCode);
            DTO.DeserializeRates(WeatherResponse);
        }

        public WeatherMapService(string name, string stateCode, string countryCode)
        {            
            WeatherResponse = CallManager.GetResponseByCityNameStateCountry(name, stateCode, countryCode);
            DTO.DeserializeRates(WeatherResponse);
        }

        public WeatherMapService(float latitude, float longitude)
        {
            WeatherResponse = CallManager.GetResponseByLatAndLong(latitude, longitude);
            DTO.DeserializeRates(WeatherResponse);   
        }

        public WeatherMapService(int zip, string countryCode)
        {
            WeatherResponse = CallManager.GetResponseByZip(zip, countryCode);
            DTO.DeserializeRates(WeatherResponse);
        }
    }
}
