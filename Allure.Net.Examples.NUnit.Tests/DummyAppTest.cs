using Allure.Net.Examples.NUnit.Tests.Library.CustomAttributes;
using Allure.Net.Examples.NUnit.Tests.Library.TestSteps;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;

namespace Allure.Net.Examples.NUnit.Tests
{
    [Layer("rest")]
    [AllureOwner("neparij")]
    [AllureFeature("Weather Forecast")]
    [AllureSuite("DummyApp")]
    [AllureNUnit]
    public class DummyAppTest
    {
        [Test]
        [Microservice("Forecast")]
        [AllureStory("Get Forecast")]
        [AllureName("Get Forecast via API")]
        [AllureTag("api", "smoke")]
        public void ShouldGetWeatherForecasts()
        {
            var forecasts = DummyAppSteps.GetWeatherForecast();
            DummyAppSteps.CheckAllForecastsInfo(forecasts);
        }
    }
}