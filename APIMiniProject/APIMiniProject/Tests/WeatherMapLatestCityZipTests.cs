using NUnit.Framework;
using APIMiniProject.HTTPManager;

namespace APIMiniProject
{
    public class WeatherMapLatestZipTests
    {
        private WeatherMapService _service;
        private WeatherMapService _invalidZipService;
        private WeatherMapService _invalidCountryService;
        private int _zip = 37188;
        private int _invalidZip = 0;
        private string _countryCode = "US";
        private string _invalidCountryCode = "USA";


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
            Assert.That(_service.DTO.LatestWeather.cod, Is.EqualTo(200));
        }

        [Test]
        public void ZipAndCountryCodeGivesCorrectNameResponse()
        {
            Assert.That(_service.DTO.LatestWeather.name.ToString(), Is.EqualTo("White House"));
        }

        [Test]
        public void InvalidZipGiveseErrorMessage()
        {
            Assert.That(_invalidZipService.DTO.LatestWeather.cod, Is.EqualTo(400));

        }
        [Test]
        public void InvalidCountryCodeGiveseErrorMessage()
        {
            Assert.That(_invalidCountryService.DTO.LatestWeather.cod, Is.EqualTo(404));

        }

    }
}