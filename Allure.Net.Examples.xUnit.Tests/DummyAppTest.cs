using Allure.Net.Examples.xUnit.Tests.Library.CustomAttributes;
using Allure.Net.Examples.xUnit.Tests.Library.TestSteps;
using Allure.Xunit.Attributes;

namespace Allure.Net.Examples.xUnit.Tests
{
    [Layer("rest")]
    [AllureOwner("neparij")]
    [AllureFeature("Weather Forecast")]
    [AllureSuite("DummyApp")]
    public class DummyAppTest
    {
        [Microservice("Forecast")]
        [AllureStory("Get Forecast")]
        [AllureXunit(DisplayName = "Get Forecast via API")]
        [AllureTag("api", "smoke")]
        public async void ShouldGetWeatherForecasts()
        {
            var forecasts = await DummyAppSteps.GetWeatherForecast();
            DummyAppSteps.CheckAllForecastsInfo(forecasts);
        }
    }
}