using System.Threading.Tasks;
using Allure.Net.Examples.xUnit.Tests.Library.CustomAttributes;
using Allure.Net.Examples.xUnit.Tests.Library.TestSteps;
using Allure.Xunit.Attributes;
using Xunit;

namespace Allure.Net.Examples.xUnit.Tests
{
    [Layer("rest")]
    [AllureOwner("neparij")]
    [AllureFeature("Issues")]
    [AllureSuite("Issues Web")]
    public class IssuesWebTest : IAsyncLifetime
    {
        private const string Owner = "allure-framework";
        private const string Repo = "allure2";
        private const string IssueTitle = "Some issue title here";

        public Task InitializeAsync()
        {
            return WebSteps.StartDriver();
        }

        public Task DisposeAsync()
        {
            return WebSteps.StopDriver();
        }

        [Tm4J("AE-T3")]
        [Microservice("Billing")]
        [AllureStory("Create new issue")]
        [AllureIssue("jira", "AE-2")]
        [AllureTag("web", "critical")]
        [AllureXunit(DisplayName = "Creating new issue authorized user")]
        public async Task ShouldCreateIssue()
        {
            await WebSteps.OpenIssuesPage(Owner, Repo);
            WebSteps.CreateIssueWithTitle(IssueTitle);
            WebSteps.ShouldSeeIssueWithTitle(IssueTitle);
        }

        [Tm4J("AE-T4")]
        [Microservice("Repository")]
        [AllureStory("Create new issue")]
        [AllureTag("web", "regress")]
        [AllureIssue("jira", "AE-1")]
        [AllureXunit(DisplayName = "Adding note to advertisement")]
        public async Task ShouldAddLabelToIssue()
        {
            await WebSteps.OpenIssuesPage(Owner, Repo);
            WebSteps.CreateIssueWithTitle(IssueTitle);
            WebSteps.ShouldSeeIssueWithTitle(IssueTitle);
        }

        [Tm4J("AE-T5")]
        [Microservice("Repository")]
        [AllureStory("Close existing issue")]
        [AllureTag("web", "regress")]
        [AllureIssue("jira", "AE-1")]
        [AllureXunit(DisplayName = "Closing new issue for authorized user")]
        public async Task ShouldCloseIssue()
        {
            await WebSteps.OpenIssuesPage(Owner, Repo);
            WebSteps.CreateIssueWithTitle(IssueTitle);
            WebSteps.CloseIssueWithTitle(IssueTitle);
            WebSteps.ShouldNotSeeIssueWithTitle(IssueTitle);
        }
    }
}