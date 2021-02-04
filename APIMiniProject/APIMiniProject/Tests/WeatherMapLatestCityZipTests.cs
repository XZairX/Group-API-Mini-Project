using NUnit.Framework;

namespace APIMiniProject
{
    public class WeatherMapLatestZipTests
    {
        private readonly int _zip = 37188;
        private readonly int _invalidZip = 0;
        private readonly string _countryCode = "US";
        private readonly string _invalidCountryCode = "USA";

        private WeatherMapService _service;
        private WeatherMapService _invalidZipService;
        private WeatherMapService _invalidCountryService;

        [OneTimeSetUp]
        public void ZipSetup()
        {
            _service = new WeatherMapService(_zip, _countryCode);
            _invalidZipService = new WeatherMapService(_invalidZip, _countryCode);
            _invalidCountryService = new WeatherMapService(_zip, _invalidCountryCode);
        }

        [Test]
        public void WebCallSuccessCheck()
        {
            Assert.That(_service.DTO.Properties.cod, Is.EqualTo(200));
        }

        [Test]
        public void ZipAndCountryCodeGivesCorrectNameResponse()
        {
            Assert.That(_service.DTO.Properties.name.ToString(), Is.EqualTo("White House"));
        }

        [Test]
        public void InvalidZipGiveseErrorMessage()
        {
            Assert.That(_invalidZipService.DTO.Properties.cod, Is.EqualTo(400));
        }

        [Test]
        public void InvalidCountryCodeGiveseErrorMessage()
        {
            Assert.That(_invalidCountryService.DTO.Properties.cod, Is.EqualTo(404));
        }
    }
}
