using APIMiniProject.DataHandling;
using APIMiniProject.HTTPManager;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIMiniProject
{
    public class WeatherMapService
    {
        public LatestWeatherMapCallManager callManager { get; set; } = new LatestWeatherMapCallManager();
        public LatestWeatherMapDTO DTO { get; set; } = new LatestWeatherMapDTO();

        public string WeatherById { get; set; }

        public WeatherMapService(int id)
        {
            WeatherById = callManager.GetResponseByCityID(id);
            DTO.DeserializeRates(WeatherById);
        }
        public WeatherMapService(string name)
        {
            WeatherById = callManager.GetResponseByCityName(name);
            DTO.DeserializeRates(WeatherById);
        }
        public WeatherMapService(string name, string stateCode)
        {
            WeatherById = callManager.GetResponseByCityNameState(name, stateCode);
            DTO.DeserializeRates(WeatherById);
        }
        public WeatherMapService(string name, string stateCode, string countryCode)
        {            
            WeatherById = callManager.GetResponseByCityNameStateCountry(name, stateCode, countryCode);
            DTO.DeserializeRates(WeatherById);
        }
        public WeatherMapService(double longitude, double latitude)
        {
            WeatherById = callManager.GetResponseByLongAndLat(longitude, latitude);
            DTO.DeserializeRates(WeatherById);
            
        }
        public WeatherMapService(int zip, string countryCode)
        {
            WeatherById = callManager.GetResponseByZip(zip, countryCode);
            DTO.DeserializeRates(WeatherById);

        }
    }
}
