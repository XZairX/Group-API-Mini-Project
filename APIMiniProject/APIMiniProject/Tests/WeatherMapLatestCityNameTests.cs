using NUnit.Framework;

namespace APIMiniProject
{
    [TestFixture]
    public class WeatherMapLatestCityNameTests
    {
        private const string _city = "Birmingham";
        private const string _cityLowercase = "birmingham";
        private const string _cityUppercase = "BIRMINGHAM";

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
