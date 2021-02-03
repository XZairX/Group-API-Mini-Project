using NUnit.Framework;

namespace APIMiniProject
{
    [TestFixture]
    public class WeatherMapLatestCityNameStateCountryTests
    {
        private const string _cityUK = "Birmingham";
        private const string _cityUS = "Miami";
        private const string _stateUK = "EN";
        private const string _stateUS = "FL";
        private const string _countryUK = "UK";
        private const string _countryUS = "US";

        private WeatherMapService CreateServiceWithArgumentCityState(
            string city, string state, string country)
        {
            return new WeatherMapService(city, state, country);
        }

        [Test]
        public void CityNameStateQuery_ValidArguments_ReturnsStatusCode200()
        {
            var sut = CreateServiceWithArgumentCityState(_cityUS, _stateUS, _stateUS);

            var result = sut.DTO.LatestWeather.cod;

            Assert.That(result, Is.EqualTo(200));
        }

        [Test]
        public void CityNameStateQuery_AlwaysReturnsCityIfNameIsValid()
        {
            var sut = CreateServiceWithArgumentCityState(_cityUS, _stateUK, _countryUK);

            var result = sut.DTO.LatestWeather.name;

            Assert.That(result, Is.EqualTo(_cityUS));
        }
    }
}
