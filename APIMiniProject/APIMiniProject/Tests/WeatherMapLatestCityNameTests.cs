using NUnit.Framework;
using APIMiniProject.HTTPManager;

namespace APIMiniProject
{
    public class WeatherMapLatestCityNameTests
    {
        public WeatherMapService service;

        [Test]
        public void WebCallSuccessCheck()
        {
            service = new WeatherMapService("Birmingham");
            Assert.That(service.DTO.LatestWeather.name.ToString(), Is.EqualTo(""));
        }

    }
}