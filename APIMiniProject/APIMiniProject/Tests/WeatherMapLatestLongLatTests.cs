using NUnit.Framework;

namespace APIMiniProject
{
    public class WeatherMapLatestLongLatTests
    {
        private readonly float _longitude = -1.89983f;
        private readonly float _latitude = 52.481419f;
        private readonly float _loughboroughLongitude = -1.2f;
        private readonly float _loughboroughLatitude = 52.7667f;
        private readonly float _invalid = 500f;
      
        private WeatherMapService _service;
        private WeatherMapService _loughboroughService;
        private WeatherMapService _invalidLongService;
        private WeatherMapService _invalidLatService;

        [OneTimeSetUp]
        public void LongitudeAndLatitudeSetup()
        {
            _service = new WeatherMapService(_latitude, _longitude);
            _loughboroughService = new WeatherMapService(_loughboroughLatitude, _loughboroughLongitude);
            _invalidLongService = new WeatherMapService(_latitude, _invalid);
            _invalidLatService = new WeatherMapService(_invalid, _longitude);
        }

        [Test]
        public void WebCallSuccessCheck()
        {
            Assert.That(_service.DTO.Properties.cod, Is.EqualTo(200));
        }

        // Known API issue where the API seemingly randomly choose one of the two Brum city IDs for the same co-ords
        [Test]
        public void LongitudeAndLatitudeReturnOneOfTheCorrectCityIDs()
        {
            Assert.That(_service.DTO.Properties.id, Is.EqualTo(2655603).Or.EqualTo(3333125));
        }

        [Test]
        public void LongitudeAndLatitudeReturnCorrectCityID()
        {
            Assert.That(_loughboroughService.DTO.Properties.id, Is.EqualTo(2643567));
        }

        [Test]
        public void InvalidLongitudeReturnsErrorMessage()
        {
            Assert.That(_invalidLongService.DTO.Properties.cod, Is.EqualTo(400));
        }

        [Test]
        public void InvalidLatitudeReturnsErrorMessage()
        {
            Assert.That(_invalidLatService.DTO.Properties.cod, Is.EqualTo(400));
        }
    }
}
