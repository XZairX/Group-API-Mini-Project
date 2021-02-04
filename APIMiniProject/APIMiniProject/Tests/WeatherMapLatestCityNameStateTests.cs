using NUnit.Framework;

namespace APIMiniProject
{
    //State ("OH" Ohio for London) seems to be broken. Works with country code though?
    [TestFixture]
    public class WeatherMapCityNameStateTests
    {
        private const string _city = "London";
        private const string _state = "US";
        private const string _invalidString = "invalidString";

        private WeatherMapService WeatherServiceWithCityAndState(
            string city, string state)
        {
            return new WeatherMapService(city, state);
        }

        [Test]
        public void CityNameStateQuery_InvalidCity_ReturnsStatusCode404()
        {
            var sut = WeatherServiceWithCityAndState(_invalidString, _invalidString);

            var result = sut.DTO.LatestWeather.cod;

            Assert.That(result, Is.EqualTo(404));
        }

        [Test]
        public void CityNameStateQuery_ValidCity_ReturnsStatusCode200()
        {
            var sut = WeatherServiceWithCityAndState(_city, _invalidString);

            var result = sut.DTO.LatestWeather.cod;

            Assert.That(result, Is.EqualTo(200));
        }

        [Test]
        public void LondonCity_DefaultValue_ReturnsCountryCodeOfGB()
        {
            var sut = new WeatherMapService(_city);

            var result = sut.DTO.LatestWeather.sys.country;

            Assert.That(result, Is.EqualTo("GB"));
        }

        [Test]
        public void LondonCity_USCountry_ReturnsCountryCodeOfUS()
        {
            var sut = WeatherServiceWithCityAndState(_city, _state);

            var result = sut.DTO.LatestWeather.sys.country;

            Assert.That(result, Is.EqualTo("US"));
        }
    }
}
