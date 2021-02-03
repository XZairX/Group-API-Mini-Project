using NUnit.Framework;

namespace APIMiniProject
{
    [TestFixture]
    public class WeatherMapLatestCityNameTests
    {
        private const string _city = "Birmingham";

        private WeatherMapService CreateServiceWithArgumentCity(string city)
        {
            return new WeatherMapService(city);
        }

        [Test]
        public void CityNameQuery_CityIsInvalid_ReturnsStatusCode404()
        {
            var sut = CreateServiceWithArgumentCity("Invalid");

            var result = sut.DTO.LatestWeather.cod;

            Assert.That(result, Is.EqualTo(404));
        }

        [Test]
        public void CityNameQuery_CityIsValid_ReturnsStatusCode200()
        {
            var sut = CreateServiceWithArgumentCity(_city);

            var result = sut.DTO.LatestWeather.cod;

            Assert.That(result, Is.EqualTo(200));
        }

        [Test]
        public void CityNameQuery_CityIsValidAndLowerCase_ReturnsCity()
        {
            var sut = CreateServiceWithArgumentCity(_city.ToLower());

            var result = sut.DTO.LatestWeather.name;

            Assert.That(result, Is.EqualTo(_city));
        }

        [Test]
        public void CityNameQuery_CityIsValidAndUpperCase_ReturnsCity()
        {
            var sut = CreateServiceWithArgumentCity(_city.ToUpper());

            var result = sut.DTO.LatestWeather.name;

            Assert.That(result, Is.EqualTo(_city));
        }
    }
}
