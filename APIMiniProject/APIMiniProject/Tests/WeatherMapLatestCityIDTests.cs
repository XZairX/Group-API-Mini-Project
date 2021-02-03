using NUnit.Framework;
using APIMiniProject.HTTPManager;

namespace APIMiniProject
{
    public class WeatherMapLatestCityIDTests
    {
        public WeatherMapService serviceTest;
        public WeatherMapService serviceTest2;
        public WeatherMapService serviceTest3;

        [OneTimeSetUp]
        public void SinglePostcodeServiceSetup()
        {
            serviceTest = new WeatherMapService(2655603);
        }

        [Test]
        public void SuccesfulRequestByCityIdReturns200()
        {
            Assert.That(serviceTest.DTO.LatestWeather.cod, Is.EqualTo(200));
        }

        [Test]
        public void RequestNotFoundByCityIdReturns400()
        {
            serviceTest2 = new WeatherMapService(-1);
            Assert.That(serviceTest2.DTO.LatestWeather.cod, Is.EqualTo(400));
        }

        [Test]
        public void RequestNotFoundByCityIdReturns404()
        {
            serviceTest3 = new WeatherMapService(37188);
            Assert.That(serviceTest3.DTO.LatestWeather.cod, Is.EqualTo(404));
        }

        [Test]
        public void JSONTest_ReturnsCorrectCountryGivenID()
        {
            Assert.That(serviceTest.DTO.LatestWeather.sys.country.ToString(), Is.EqualTo("GB"));
        }

        [Test]
        public void JSONTest_ReturnsCorrectCountryNameGivenID()
        {
            Assert.That(serviceTest.DTO.LatestWeather.name.ToString(), Is.EqualTo("Birmingham"));
        }
    }
}
