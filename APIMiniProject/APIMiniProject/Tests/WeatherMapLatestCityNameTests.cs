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

        [Test]
        public void CityNameQuery_CityIsInvalid_ReturnsError404()
        {
            var sut = CreateServiceWithArgumentCity(string.Empty);

            var result = sut.DTO.LatestWeather.name;

            Assert.That(result.ToString(), Is.EqualTo("djksdfjl"));
        }

        [Test]
        public void CityNameQuery_CityIsValidAndLowerCase_ReturnsCity()
        {
            var sut = CreateServiceWithArgumentCity(_city.ToLower());

            var result = sut.DTO.LatestWeather.name;

            Assert.That(result, Is.EqualTo(_city));
        }

        [Test]
        public void CityNameQuery_CityIsValidAndUpperCase_ReturnsCity()
        {
            var sut = CreateServiceWithArgumentCity(_city.ToUpper());

            var result = sut.DTO.LatestWeather.name;

            Assert.That(result, Is.EqualTo(_city));
        }
    }
}
