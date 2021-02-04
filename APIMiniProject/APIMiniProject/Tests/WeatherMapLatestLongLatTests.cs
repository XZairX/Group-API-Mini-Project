using NUnit.Framework;
using APIMiniProject.HTTPManager;

namespace APIMiniProject
{
    public class WeatherMapLatestLongLatTests
    {
        private WeatherMapService service;
        private WeatherMapService loughboroughService;
        private WeatherMapService invalidLongService;
        private WeatherMapService invalidLatService;
        private float _longitude = -1.89983f;
        private float _latitude = 52.481419f;
        private float _loughboroughLongitude = -1.2f;
        private float _loughboroughLatitude = 52.7667f;
        private float _invalid = 500f;

        [OneTimeSetUp]
        public void LongitudeAndLatitudeSetup()
        {
            service = new WeatherMapService(_latitude, _longitude);
            loughboroughService = new WeatherMapService(_loughboroughLatitude, _loughboroughLongitude);
            invalidLongService = new WeatherMapService(_latitude, _invalid);
            invalidLatService = new WeatherMapService(_invalid, _longitude);
        }

        [Test]
        public void WebCallSuccessCheck()
        {
            Assert.That(service.DTO.Properties.cod, Is.EqualTo(200));
        }

        // Known API issue
        [Test]
        public void LongitudeAndLatitudeReturnOneOfTheCorrectCityIDs()
        {
            Assert.That(service.DTO.Properties.id, Is.EqualTo(2655603).Or.EqualTo(3333125));
        }

        [Test]
        public void LongitudeAndLatitudeReturnCorrectCityID()
        {
            Assert.That(loughboroughService.DTO.Properties.id, Is.EqualTo(2643567));
        }

        [Test]
        public void InvalidLongitudeReturnsErrorMessage()
        {
            Assert.That(invalidLongService.DTO.Properties.cod, Is.EqualTo(400));
        }

        [Test]
        public void InvalidLatitudeReturnsErrorMessage()
        {
            Assert.That(invalidLatService.DTO.Properties.cod, Is.EqualTo(400));
        }

    }
}