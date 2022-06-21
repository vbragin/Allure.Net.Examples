using Allure.Net.Examples.NUnit.Tests.Library.CustomAttributes;
using Allure.Net.Examples.NUnit.Tests.Library.TestSteps;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;

namespace Allure.Net.Examples.NUnit.Tests
{
    [Layer("rest")]
    [AllureOwner("neparij")]
    [AllureFeature("Issues")]
    [AllureSuite("Issues Rest")]
    [AllureNUnit]
    public class IssuesRestTest
    {
        private const string Owner = "allure-framework";
        private const string Repo = "allure2";

        [Test]
        [Tm4J("AE-T1")]
        [Microservice("Billing")]
        [AllureStory("Create new issue")]
        [AllureTag("api", "smoke")]
        [AllureName("Create issue via api")]
        public void ShouldCreateUserNote([Values("First Note", "Second Note")] string title)
        {
            RestSteps.CreateIssueWithTitle(Owner, Repo, title);
            RestSteps.ShouldSeeIssueWithTitle(Owner, Repo, title);
        }

        [Test]
        [Tm4J("AE-T2")]
        [Microservice("Repository")]
        [AllureStory("Close existing issue")]
        [AllureTag("web", "regress")]
        [AllureIssue("AE-1")]
        [AllureName("Close issue via api")]
        public void ShouldDeleteUserNote([Values("First Note", "Second Note")] string title)
        {
            RestSteps.CreateIssueWithTitle(Owner, Repo, title);
            RestSteps.CloseIssueWithTitle(Owner, Repo, title);
        }
    }
}