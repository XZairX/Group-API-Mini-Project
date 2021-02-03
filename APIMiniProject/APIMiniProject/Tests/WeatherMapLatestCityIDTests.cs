using NUnit.Framework;
using APIMiniProject.HTTPManager;

namespace APIMiniProject
{
    public class WeatherMapLatestCityIDTests
    {
        public WeatherMapService service;

        [Test]
        public void WebCallSuccessCheck()
        {
            service = new WeatherMapService(833);
            Assert.That(service.DTO.LatestWeather.name.ToString(), Is.EqualTo(""));
        }

    }
}
