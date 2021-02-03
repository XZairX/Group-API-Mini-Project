using NUnit.Framework;

namespace APIMiniProject
{
    [TestFixture]
    public class WeatherMapCityNameStateTests
    {
        private const string _city = "London";
        private const string _state = "OH";
        private const string _invalidString = "invalidString";

        [Test]
        public void CityNameStateQuery_InvalidCity_ReturnsStatusCode404()
        {
            var sut = new WeatherMapService(
                _invalidString, _invalidString);

            var result = sut.DTO.LatestWeather.cod;

            Assert.That(result, Is.EqualTo(404));
        }

        [Test]
        public void CityNameStateQuery_ValidCity_ReturnsStatusCode200()
        {
            var sut = new WeatherMapService(_city, _invalidString);

            var result = sut.DTO.LatestWeather.cod;

            Assert.That(result, Is.EqualTo(200));
        }

        //State cannot be used alone and requires a country
        //Using a non-US country will override the state
        [Test]
        public void LondonCity_USCountry_ReturnsCountryCodeOfUS()
        {
            var sut = new WeatherMapService(_city, _state);

            var result = sut.DTO.LatestWeather.name;

            Assert.That(result, Is.EqualTo(_city));
        }
    }
}
