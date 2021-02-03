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

        private WeatherMapService CreateServiceWithArgumentCity(string city)
        {
            return new WeatherMapService(city);
        }

        [Ignore("In progress")]
        [Test]
        public void CityNameQuery_InvalidCity_ReturnsError404()
        {
            string invalidCity = "invalidCity";

            var result = new WeatherMapService(invalidCity);

            Assert.That(result.ToString(), Is.EqualTo(""));
        }

        [Test]
        public void CityNameQuery_CityIsValidAndHasUppercaseFirstLetter_ReturnsCity()
        {
            var sut = CreateServiceWithArgumentCity(_city);

            var result = sut.DTO.LatestWeather.name;

            Assert.That(result, Is.EqualTo(_city));
        }
    }
}