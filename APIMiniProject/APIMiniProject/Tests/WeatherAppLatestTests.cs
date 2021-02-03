﻿using NUnit.Framework;
using APIMiniProject.HTTPManager;

namespace APIMiniProject
{
    public class UnitTest1
    {
        public WeatherMapService service;

        [Test]
        public void WebCallSuccessCheck()
        {
            service = new WeatherMapService(833);
            Assert.That(service.DTO.LatestWeather.name.ToString(), Is.EqualTo(""));
        }

    }
}
