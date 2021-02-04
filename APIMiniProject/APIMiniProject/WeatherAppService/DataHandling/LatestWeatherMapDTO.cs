using Newtonsoft.Json;

namespace APIMiniProject.DataHandling
{
    public class LatestWeatherMapDTO
    {
        public LatestWeatherRoot Properties { get; set; }

        public void DeserializeRates(string weatherParam)
        {
            Properties = JsonConvert.DeserializeObject<LatestWeatherRoot>(weatherParam);
        }
    }
}
