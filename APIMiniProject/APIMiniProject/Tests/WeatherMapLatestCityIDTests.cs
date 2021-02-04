using NUnit.Framework;
using APIMiniProject.HTTPManager;

namespace APIMiniProject
{
    public class WeatherMapLatestCityIDTests
    {
        private WeatherMapService _service;
        private WeatherMapService _invalidIDService;
        private WeatherMapService _notFoundIDService;

        [OneTimeSetUp]
        public void IDSetup()
        {
            _service = new WeatherMapService(2655603);
            _invalidIDService = new WeatherMapService(-1);
            _notFoundIDService = new WeatherMapService(37188);
        }

        [Test]
        public void SuccesfulRequestByCityIdReturns200()
        {
            Assert.That(_service.DTO.LatestWeather.cod, Is.EqualTo(200));
        }

        [Test]
        public void RequestNotFoundByCityIdReturns400()
        {
            Assert.That(_invalidIDService.DTO.LatestWeather.cod, Is.EqualTo(400));
        }

        [Test]
        public void RequestNotFoundByCityIdReturns404()
        {
            Assert.That(_notFoundIDService.DTO.LatestWeather.cod, Is.EqualTo(404));
        }

        [Test]
        public void JSONTest_ReturnsCorrectCountryGivenID()
        {
            Assert.That(_service.DTO.LatestWeather.sys.country.ToString(), Is.EqualTo("GB"));
        }

        [Test]
        public void JSONTest_ReturnsCorrectCountryNameGivenID()
        {
            Assert.That(_service.DTO.LatestWeather.name.ToString(), Is.EqualTo("Birmingham"));
        }
    }
}
