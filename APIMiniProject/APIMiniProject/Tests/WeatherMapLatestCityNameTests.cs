using NUnit.Framework;

namespace APIMiniProject
{
    [TestFixture]
    public class WeatherMapLatestCityNameTests
    {
        private const string _city = "London";
        private const string _cityLowercase = "london";
        private const string _cityUppercase = "LONDON";

        private WeatherMapService WeatherServiceWithCity(string city)
        {
            return new WeatherMapService(city);
        }

        [Test]
        public void CityNameQuery_CityIsInvalid_ReturnsStatusCode404()
        {
            var sut = WeatherServiceWithCity("InvalidString");

            var result = sut.DTO.LatestWeather.cod;

            Assert.That(result, Is.EqualTo(404));
        }

        [Test]
        public void CityNameQuery_CityIsValid_ReturnsStatusCode200()
        {
            var sut = WeatherServiceWithCity(_city);

            var result = sut.DTO.LatestWeather.cod;

            Assert.That(result, Is.EqualTo(200));
        }

        [TestCase(_cityLowercase)]
        [TestCase(_cityUppercase)]
        public void CityNameQuery_CityIsValid_ReturnsCityRegardlessOfLetterCasing(string city)
        {
            var sut = WeatherServiceWithCity(city);

            var result = sut.DTO.LatestWeather.name;
            
            Assert.That(result, Is.EqualTo(_city));
        }
    }
}
