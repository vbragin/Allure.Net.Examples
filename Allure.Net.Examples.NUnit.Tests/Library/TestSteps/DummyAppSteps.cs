using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using Allure.Commons;
using Allure.Net.Examples.xUnit.Tests.Library.Models;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;

namespace Allure.Net.Examples.NUnit.Tests.Library.TestSteps
{
    public static class DummyAppSteps
    {
        private static readonly HttpClientHandler HttpClientHandler = new() 
        { 
            ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator
        };
        private static readonly HttpClient HttpClient = new(HttpClientHandler);
        private const string BaseUrl = "https://localhost:5001";

        [AllureStep("Get weather forecast info from API")]
        public static IEnumerable<WeatherForecast> GetWeatherForecast()
        {
            var result = AllureLifecycle.Instance.WrapInStep<IEnumerable<WeatherForecast>>(() =>
            {
                return HttpClient.GetFromJsonAsync<IEnumerable<WeatherForecast>>($"{BaseUrl}/WeatherForecast")
                    .GetAwaiter()
                    .GetResult();
            }, $"[GET] {BaseUrl}/WeatherForecast");

            Assert.That(result, Is.Not.Null);
            return result;
        }

        [AllureStep("Check forecasts")]
        public static void CheckAllForecastsInfo(IEnumerable<WeatherForecast> weatherForecasts)
        {
            var forecasts = weatherForecasts.ToList();
            forecasts.ForEach(forecast =>
            {
                AllureLifecycle.Instance.WrapInStep(() =>
                {
                    CheckForecastDateInRange(forecast, DateTime.Today, DateTime.Today.AddDays(7));
                    CheckForecastFahrenheitScale(forecast);
                }, $"Check forecast {forecasts.GetEnumerator().Current} info");
            });
        }

        [AllureStep("Check that forecast date is in range between {1} and {2}")]
        private static void CheckForecastDateInRange(WeatherForecast forecast, DateTime from, DateTime to)
        {
            Assert.That(forecast.Date, Is.InRange(from, to));
        }
        
        [AllureStep("Check that forecast fahrenheit scale is according to celsius")]
        private static void CheckForecastFahrenheitScale(WeatherForecast forecast)
        {
            Assert.That(forecast.TemperatureF, Is.EqualTo(32 + (int)(forecast.TemperatureC / 0.5556)));
        }
    }
}