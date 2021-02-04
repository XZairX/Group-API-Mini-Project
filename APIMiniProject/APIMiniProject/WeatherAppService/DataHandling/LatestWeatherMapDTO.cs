using Newtonsoft.Json;

namespace APIMiniProject.DataHandling
{
    public class LatestWeatherMapDTO
    {
        public LatestWeatherRoot LatestWeather { get; set; }

        public void DeserializeRates(string weatherParam)
        {
            LatestWeather = JsonConvert.DeserializeObject<LatestWeatherRoot>(weatherParam);
        }
    }
}
