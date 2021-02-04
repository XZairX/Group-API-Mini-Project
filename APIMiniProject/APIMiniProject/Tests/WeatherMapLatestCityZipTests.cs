using NUnit.Framework;

namespace APIMiniProject
{
    [TestFixture]
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
            Assert.That(_service.DTO.Properties.Cod, Is.EqualTo(200));
        }

        [Test]
        public void ZipAndCountryCodeGivesCorrectNameResponse()
        {
            Assert.That(_service.DTO.Properties.Name.ToString(), Is.EqualTo("White House"));
        }

        [Test]
        public void InvalidZipGiveseErrorMessage()
        {
            Assert.That(_invalidZipService.DTO.Properties.Cod, Is.EqualTo(400));
        }

        [Test]
        public void InvalidCountryCodeGiveseErrorMessage()
        {
            Assert.That(_invalidCountryService.DTO.Properties.Cod, Is.EqualTo(404));
        }
    }
}
