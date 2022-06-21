using Allure.Net.Examples.xUnit.Tests.Library.CustomAttributes;
using Allure.Net.Examples.xUnit.Tests.Library.TestSteps;
using Allure.Xunit.Attributes;
using Allure.Xunit.StepAttribute;
using Xunit;

namespace Allure.Net.Examples.xUnit.Tests
{
    [Layer("rest")]
    [AllureOwner("neparij")]
    [AllureFeature("Issues")]
    [AllureSuite("Issues Rest")]
    public class IssuesRestTest
    {
        private const string Owner = "allure-framework";
        private const string Repo = "allure2";

        [Tm4J("AE-T1")]
        [Microservice("Billing")]
        [AllureStory("Create new issue")]
        [AllureTag("api", "smoke")]
        [AllureXunitTheory(DisplayName = "Create issue via api")]
        [InlineData("First Note")]
        [InlineData("Second Note")]
        public void ShouldCreateUserNote(string title)
        {
            RestSteps.CreateIssueWithTitle(Owner, Repo, title);
            RestSteps.ShouldSeeIssueWithTitle(Owner, Repo, title);
        }


        [Tm4J("AE-T2")]
        [Microservice("Repository")]
        [AllureStory("Close existing issue")]
        [AllureTag("web", "regress")]
        [AllureIssue("AE-1")]
        [AllureXunitTheory(DisplayName = "Close issue via api")]
        [InlineData("First Note")]
        [InlineData("Second Note")]
        public void ShouldDeleteUserNote([Name("Title")] string title)
        {
            RestSteps.CreateIssueWithTitle(Owner, Repo, title);
            RestSteps.CloseIssueWithTitle(Owner, Repo, title);
        }
    }
}