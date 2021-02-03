using NUnit.Framework;

namespace APIMiniProject
{
    [TestFixture]
    public class WeatherMapLatestCityNameStateCountryTests
    {
        private const string _city = "London";
        private const string _state = "OH";
        private const string _countryUK = "GB";
        private const string _countryUS = "US";
        private const string _invalidString = "invalidString";

        private WeatherMapService CreateServiceWithArgumentCityState(
            string city, string state, string country)
        {
            return new WeatherMapService(city, state, country);
        }

        [Test]
        public void LondonCity_DefaultValue_ReturnsCountryCodeOfGB()
        {
            var sut = new WeatherMapService(_city);

            var result = sut.DTO.LatestWeather.sys.country;

            Assert.That(result, Is.EqualTo("GB"));
        }

        //State cannot be used alone and requires a country
        //Using a non-US country will override the state
        [Test]
        public void LondonCity_USCountry_ReturnsCountryCodeOfUS()
        {
            var sut = new WeatherMapService(_city, _countryUS);

            var result = sut.DTO.LatestWeather.sys.country;

            Assert.That(result, Is.EqualTo("US"));
        }

        [Test]
        public void LondonCity_USStateAndUKCountry_ReturnsCountryCodeOfUK()
        {
            var sut = new WeatherMapService(_city, _state, _countryUK);

            var result = sut.DTO.LatestWeather.sys.country;

            Assert.That(result, Is.EqualTo("GB"));
        }

        [Test]
        public void LondonCity_USStateAndUSCountry_ReturnsCountryCodeOfUS()
        {
            var sut = new WeatherMapService(_city, _state, _countryUS);

            var result = sut.DTO.LatestWeather.sys.country;

            Assert.That(result, Is.EqualTo("US"));
        }

        [Test]
        public void LondonCity_InvalidStateAndUSCountry_ReturnsDefaultCountryCode()
        {
            var sut = new WeatherMapService(_city, _invalidString, _countryUS);

            var result = sut.DTO.LatestWeather.sys.country;

            Assert.That(result, Is.EqualTo("GB"));
        }

        [Test]
        public void LondonCity_USStateAndInvalidCountry_ReturnsDefaultCountryCode()
        {
            var sut = new WeatherMapService(_city, _state, _invalidString);

            var result = sut.DTO.LatestWeather.sys.country;

            Assert.That(result, Is.EqualTo("GB"));
        }

        [Test]
        public void CityNameStateQuery_ValidArguments_ReturnsStatusCode200()
        {
            var sut = CreateServiceWithArgumentCityState(_city, _state, _countryUS);

            var result = sut.DTO.LatestWeather.cod;

            Assert.That(result, Is.EqualTo(200));
        }

        [Test]
        public void CityNameStateQuery_AlwaysReturnsCityIfNameIsValid()
        {
            var sut = CreateServiceWithArgumentCityState(_city, _state, _countryUS);

            var result = sut.DTO.LatestWeather.name;

            Assert.That(result, Is.EqualTo(_city));
        }
    }
}
