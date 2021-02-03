using NUnit.Framework;
using APIMiniProject.HTTPManager;

namespace APIMiniProject
{
    public class WeatherMapLatestLongLatTests
    {
        private WeatherMapService service;
        private WeatherMapService invalidLongService;
        private WeatherMapService invalidLatService;
        private double _longitude = -1.8998;
        private double _latitude = 52.4814;
        private double _invalid = 500;

        [OneTimeSetUp]
        public void LongitudeAndLatitudeSetup()
        {
            service = new WeatherMapService(_longitude, _latitude);

            invalidLongService = new WeatherMapService(_invalid, _latitude);
            invalidLatService = new WeatherMapService(_longitude, _invalid);
        }

        [Test]
        public void WebCallSuccessCheck()
        {
            Assert.That(service.DTO.LatestWeather.cod, Is.EqualTo(200));
        }

        [Test]
        public void LongitudeAndLatitudeReturnCorrectCityID()
        {
            Assert.That(service.DTO.LatestWeather.id, Is.EqualTo(3333125));
        }

        [Test]
        public void InvalidLongitudeReturnsErrorMessage()
        {
            Assert.That(invalidLongService.DTO.LatestWeather.cod, Is.EqualTo(400));
        }

        [Test]
        public void InvalidLatitudeReturnsErrorMessage()
        {
            Assert.That(invalidLatService.DTO.LatestWeather.cod, Is.EqualTo(400));
        }

    }
}