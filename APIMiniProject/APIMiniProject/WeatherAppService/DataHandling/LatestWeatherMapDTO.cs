using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
