using NUnit.Framework;

namespace APIMiniProject
{
    [TestFixture]
    public class WeatherMapLatestLatLongTests
    {
        private readonly float _latitude = 52.481419f;
        private readonly float _longitude = -1.89983f;
        private readonly float _loughboroughLatitude = 52.7667f;
        private readonly float _loughboroughLongitude = -1.2f;
        private readonly float _invalid = 500f;

        private WeatherMapService _service;
        private WeatherMapService _loughboroughService;
        private WeatherMapService _invalidLongService;
        private WeatherMapService _invalidLatService;

        [OneTimeSetUp]
        public void LatitudeAndLongitudeSetup()
        {
            _service = new WeatherMapService(_latitude, _longitude);
            _loughboroughService = new WeatherMapService(_loughboroughLatitude, _loughboroughLongitude);
            _invalidLatService = new WeatherMapService(_invalid, _longitude);
            _invalidLongService = new WeatherMapService(_latitude, _invalid);
        }

        [Test]
        public void WebCallSuccessCheck()
        {
            Assert.That(_service.DTO.Properties.cod, Is.EqualTo(200));
        }

        // Known API issue where the API seemingly randomly choose one of the two Brum city IDs for the same co-ords
        [Test]
        public void LatitudeAndLongitudeReturnOneOfTheCorrectCityIDs()
        {
            Assert.That(_service.DTO.Properties.id, Is.EqualTo(2655603).Or.EqualTo(3333125));
        }

        [Test]
        public void LatitudeAndLongitudeReturnCorrectCityID()
        {
            Assert.That(_loughboroughService.DTO.Properties.id, Is.EqualTo(2643567));
        }

        [Test]
        public void InvalidLatitudeReturnsErrorMessage()
        {
            Assert.That(_invalidLatService.DTO.Properties.cod, Is.EqualTo(400));
        }

        [Test]
        public void InvalidLongitudeReturnsErrorMessage()
        {
            Assert.That(_invalidLongService.DTO.Properties.cod, Is.EqualTo(400));
        }
    }
}
