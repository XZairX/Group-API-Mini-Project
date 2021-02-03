using NUnit.Framework;

namespace APIMiniProject
{
    public class WeatherMapLatestCityNameTests
    {
        private const string _city = "Birmingham";

        private WeatherMapService _service;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            _service = new WeatherMapService(_city);
        }

        [Test]
        public void CityNameQuery_ReturnsCity()
        {
            var result = _service.DTO.LatestWeather.name;

            Assert.That(result, Is.EqualTo(_city));
        }

    }
}