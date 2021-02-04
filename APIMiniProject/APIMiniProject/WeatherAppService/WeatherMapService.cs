using APIMiniProject.DataHandling;
using APIMiniProject.HTTPManager;

namespace APIMiniProject
{
    public class WeatherMapService
    {
        public LatestWeatherMapCallManager CallManager { get; set; } = new LatestWeatherMapCallManager();
        public LatestWeatherMapDTO DTO { get; set; } = new LatestWeatherMapDTO();

        public string WeatherById { get; set; }

        public WeatherMapService(int id)
        {
            WeatherById = CallManager.GetResponseByCityID(id);
            DTO.DeserializeRates(WeatherById);
        }

        public WeatherMapService(string name)
        {
            WeatherById = CallManager.GetResponseByCityName(name);
            DTO.DeserializeRates(WeatherById);
        }

        public WeatherMapService(string name, string stateCode)
        {
            WeatherById = CallManager.GetResponseByCityNameState(name, stateCode);
            DTO.DeserializeRates(WeatherById);
        }

        public WeatherMapService(string name, string stateCode, string countryCode)
        {            
            WeatherById = CallManager.GetResponseByCityNameStateCountry(name, stateCode, countryCode);
            DTO.DeserializeRates(WeatherById);
        }

        public WeatherMapService(double longitude, double latitude)
        {
            WeatherById = CallManager.GetResponseByLongAndLat(longitude, latitude);
            DTO.DeserializeRates(WeatherById);   
        }

        public WeatherMapService(int zip, string countryCode)
        {
            WeatherById = CallManager.GetResponseByZip(zip, countryCode);
            DTO.DeserializeRates(WeatherById);
        }
    }
}
