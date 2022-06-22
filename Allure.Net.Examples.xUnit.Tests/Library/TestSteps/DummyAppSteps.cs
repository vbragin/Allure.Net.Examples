using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Allure.Net.Examples.xUnit.Tests.Library.Models;
using Allure.Xunit;
using Allure.Xunit.StepAttribute;
using Xunit;

namespace Allure.Net.Examples.xUnit.Tests.Library.TestSteps
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
        public static async Task<IEnumerable<WeatherForecast>> GetWeatherForecast()
        {
            var result = await Steps.Step($"[GET] {BaseUrl}/WeatherForecast", () => HttpClient
                .GetFromJsonAsync<IEnumerable<WeatherForecast>>($"{BaseUrl}/WeatherForecast"));

            Assert.NotNull(result);
            return result!;
        }

        [AllureStep("Check forecasts")]
        public static void CheckAllForecastsInfo(IEnumerable<WeatherForecast> weatherForecasts)
        {
            var forecasts = weatherForecasts.ToList();
            forecasts.ForEach(forecast =>
            {
                Steps.Step($"Check forecast {forecasts.GetEnumerator().Current} info", () =>
                {
                    CheckForecastDateInRange(forecast, DateTime.Today, DateTime.Today.AddDays(7));
                    CheckForecastFahrenheitScale(forecast);
                });
            });
        }

        [AllureStep("Check that forecast date is in range between {from} and {to}")]
        private static void CheckForecastDateInRange(WeatherForecast forecast, DateTime from, DateTime to)
        {
            Assert.InRange(forecast.Date, from, to);
        }
        
        [AllureStep("Check that forecast fahrenheit scale is according to celsius")]
        private static void CheckForecastFahrenheitScale(WeatherForecast forecast)
        {
            Assert.Equal(32 + (int)(forecast.TemperatureC / 0.5556), forecast.TemperatureF);
        }
    }
}