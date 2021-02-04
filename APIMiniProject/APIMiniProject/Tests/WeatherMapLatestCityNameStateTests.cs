using NUnit.Framework;

namespace APIMiniProject
{
    // API doc states to use a state for second parameter but this returns a nullreference exception
    // Using a country as a second parameter overcomes this issue and the functionality is as intended
    [TestFixture]
    public class WeatherMapCityNameStateTests
    {
        private const string _city = "london";
        private const string _state = "Us";
        private const string _stateLowercase = "us";
        private const string _stateUppercase = "US";
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

            var result = sut.DTO.Properties.cod;

            Assert.That(result, Is.EqualTo(404));
        }

        [Test]
        public void CityNameStateQuery_ValidCity_ReturnsStatusCode200()
        {
            var sut = WeatherServiceWithCityAndState(_city, _invalidString);

            var result = sut.DTO.Properties.cod;

            Assert.That(result, Is.EqualTo(200));
        }

        [Test]
        public void LondonCity_DefaultValue_ReturnsCountryCodeNotEqualToUS()
        {
            var sut = new WeatherMapService(_city);

            var result = sut.DTO.Properties.sys.country;

            Assert.That(result, Is.Not.EqualTo("US"));
        }

        [Test]
        public void LondonCity_USCountry_ReturnsUSCountryCode()
        {
            var sut = WeatherServiceWithCityAndState(_city, _state);

            var result = sut.DTO.Properties.sys.country;

            Assert.That(result, Is.EqualTo("US"));
        }

        [TestCase(_stateLowercase)]
        [TestCase(_stateUppercase)]
        public void CityNameStateQuery_StateIsValid_ReturnsCountryCodeRegardlessOfLetterCasing(string state)
        {
            var sut = WeatherServiceWithCityAndState(_city, state);

            var result = sut.DTO.Properties.sys.country;

            Assert.That(result, Is.EqualTo("US"));
        }
    }
}
