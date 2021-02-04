using NUnit.Framework;

namespace APIMiniProject
{
    [TestFixture]
    public class WeatherMapLatestCityNameStateCountryTests
    {
        private const string _city = "London";
        private const string _state = "OH";
        private const string _countryGB = "GB";
        private const string _countryUS = "US";
        private const string _invalidString = "invalidString";

        private WeatherMapService WeatherServiceWithCityStateAndCountry(
            string city, string state, string country)
        {
            return new WeatherMapService(city, state, country);
        }

        [Test]
        public void CityNameStateQuery_InvalidCity_ReturnsStatusCode404()
        {
            var sut = WeatherServiceWithCityStateAndCountry(
                _invalidString, _invalidString, _invalidString);

            var result = sut.DTO.LatestWeather.cod;

            Assert.That(result, Is.EqualTo(404));
        }

        [Test]
        public void CityNameStateQuery_ValidCity_ReturnsStatusCode200()
        {
            var sut = WeatherServiceWithCityStateAndCountry(
                _city, _invalidString, _invalidString);

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
        //---
        //State cannot be used alone and requires a country
        //Using a non-US country will override the state
        [Test]
        public void LondonCity_USCountry_ReturnsCountryCodeOfUS()
        {
            var sut = new WeatherMapService(_city, _countryUS);

            var result = sut.DTO.LatestWeather.sys.country;

            Assert.That(result, Is.EqualTo("US"));
        }
        //---
        [Test]
        public void LondonCity_InvalidStateAndUSCountry_ReturnsDefaultCountryCode()
        {
            var sut = WeatherServiceWithCityStateAndCountry(
                _city, _invalidString, _countryUS);

            var result = sut.DTO.LatestWeather.sys.country;

            Assert.That(result, Is.EqualTo("GB"));
        }

        [Test]
        public void LondonCity_StateAndInvalidCountry_ReturnsDefaultCountryCode()
        {
            var sut = WeatherServiceWithCityStateAndCountry(
                _city, _state, _invalidString);

            var result = sut.DTO.LatestWeather.sys.country;

            Assert.That(result, Is.EqualTo("GB"));
        }

        [Test]
        public void LondonCity_StateAndUKCountry_ReturnsDefaultCountryCodeOfGB()
        {
            var sut = WeatherServiceWithCityStateAndCountry(
                _city, _state, _countryGB);

            var result = sut.DTO.LatestWeather.sys.country;

            Assert.That(result, Is.EqualTo("GB"));
        }

        [Test]
        public void LondonCity_StateAndUSCountry_ReturnsCountryCodeOfUS()
        {
            var sut = WeatherServiceWithCityStateAndCountry(
                _city, _state, _countryUS);

            var result = sut.DTO.LatestWeather.sys.country;

            Assert.That(result, Is.EqualTo("US"));
        }
    }
}
