using NUnit.Framework;

namespace APIMiniProject
{
    // State cannot be used alone and requires a country to have any changes occur
    // Using a non-US country will override the state as if it was never supplied
    [TestFixture]
    public class WeatherMapLatestCityNameStateCountryTests
    {
        private const string _city = "london";
        private const string _state = "oh";
        private const string _countryGB = "gb";
        private const string _countryUS = "Us";
        private const string _countryUSLowercase = "us";
        private const string _countryUSUppercase = "US";
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

            var result = sut.DTO.Properties.cod;

            Assert.That(result, Is.EqualTo(404));
        }

        [Test]
        public void CityNameStateQuery_ValidCity_ReturnsStatusCode200()
        {
            var sut = WeatherServiceWithCityStateAndCountry(
                _city, _invalidString, _invalidString);

            var result = sut.DTO.Properties.cod;

            Assert.That(result, Is.EqualTo(200));
        }

        [Test]
        public void LondonCity_InvalidStateAndUSCountry_ReturnsLondonDefaultCountryCode()
        {
            var sut = WeatherServiceWithCityStateAndCountry(
                _city, _invalidString, _countryUS);

            var result = sut.DTO.Properties.sys.country;

            Assert.That(result, Is.Not.EqualTo("US"));
        }

        [Test]
        public void LondonCity_StateAndInvalidCountry_ReturnsLondonDefaultCountryCode()
        {
            var sut = WeatherServiceWithCityStateAndCountry(
                _city, _state, _invalidString);

            var result = sut.DTO.Properties.sys.country;

            Assert.That(result, Is.Not.EqualTo("US"));
        }

        [Test]
        public void LondonCity_StateAndUKCountry_ReturnsLondonDefaultCountryCode()
        {
            var sut = WeatherServiceWithCityStateAndCountry(
                _city, _state, _countryGB);

            var result = sut.DTO.Properties.sys.country;

            Assert.That(result, Is.Not.EqualTo("US"));
        }

        [Test]
        public void LondonCity_StateAndUSCountry_ReturnsUSCountryCode()
        {
            var sut = WeatherServiceWithCityStateAndCountry(
                _city, _state, _countryUS);

            var result = sut.DTO.Properties.sys.country;

            Assert.That(result, Is.EqualTo("US"));
        }

        [TestCase(_countryUSLowercase)]
        [TestCase(_countryUSUppercase)]
        public void CityNameStateQuery_StateIsValid_ReturnsCountryCodeRegardlessOfLetterCasing(string country)
        {
            var sut = WeatherServiceWithCityStateAndCountry(_city, _state, country);

            var result = sut.DTO.Properties.sys.country;

            Assert.That(result, Is.EqualTo("US"));
        }
    }
}
