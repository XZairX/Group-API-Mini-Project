using NUnit.Framework;

namespace APIMiniProject
{
    [TestFixture]
    public class WeatherMapLatestCityNameStateCountryTests
    {
        private const string _cityUK = "Birmingham";
        private const string _cityUS = "Miami";
        private const string _stateUK = "England";
        private const string _stateUS = "FL";
        private const string _countryUS = "US";

        private WeatherMapService CreateServiceWithArgumentCityState(
            string city, string state, string country)
        {
            return new WeatherMapService(city, state, country);
        }

        [Test]
        public void CityNameStateQuery_StateIsInvalid_ReturnsStatusCode404()
        {
            var sut = CreateServiceWithArgumentCityState(_cityUS, _stateUS, _stateUS);

            var result = sut.DTO.LatestWeather.cod;

            Assert.That(result, Is.EqualTo(404));
        }
    }
}
