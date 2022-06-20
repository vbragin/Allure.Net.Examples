using Allure.Net.Examples.NUnit.Tests.Library.CustomAttributes;
using Allure.Net.Examples.NUnit.Tests.Library.TestSteps;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;

namespace Allure.Net.Examples.NUnit.Tests;

[Layer("rest")]
[AllureOwner("neparij")]
[AllureFeature("Issues")]
[AllureSuite("Issues Web")]
[AllureNUnit]
public class IssuesWebTest
{
    private const string Owner = "allure-framework";
    private const string Repo = "allure2";
    private const string IssueTitle = "Some issue title here";
    
    [OneTimeSetUp]
    public void SetUpOnce()
    {
        WebSteps.StartDriver();
    }

    [Test]
    [Tm4J("AE-T3")]
    [Microservice("Billing")]
    [AllureStory("Create new issue")]
    [AllureIssue("jira", "AE-2")]
    [AllureTag("web", "critical")]
    [AllureName("Creating new issue authorized user")]
    public void ShouldCreateIssue()
    {
        WebSteps.OpenIssuesPage(Owner, Repo);
        WebSteps.CreateIssueWithTitle(IssueTitle);
        WebSteps.ShouldSeeIssueWithTitle(IssueTitle);
    }
    
    [Test]
    [Tm4J("AE-T4")]
    [Microservice("Repository")]
    [AllureStory("Create new issue")]
    [AllureTag("web", "regress")]
    [AllureIssue("jira", "AE-1")]
    [AllureName("Adding note to advertisement")]
    public void ShouldAddLabelToIssue() {
        WebSteps.OpenIssuesPage(Owner, Repo);
        WebSteps.CreateIssueWithTitle(IssueTitle);
        WebSteps.ShouldSeeIssueWithTitle(IssueTitle);
    }
    
    [Test]
    [Tm4J("AE-T5")]
    [Microservice("Repository")]
    [AllureStory("Close existing issue")]
    [AllureTag("web", "regress")]
    [AllureIssue("jira", "AE-1")]
    [AllureName("Closing new issue for authorized user")]
    public void ShouldCloseIssue() {
        WebSteps.OpenIssuesPage(Owner, Repo);
        WebSteps.CreateIssueWithTitle(IssueTitle);
        WebSteps.CloseIssueWithTitle(IssueTitle);
        WebSteps.ShouldNotSeeIssueWithTitle(IssueTitle);
    }

    [OneTimeTearDown]
    public void TearDownOnce()
    {
        AllureExtensions.WrapSetUpTearDownParams(WebSteps.StopDriver, "Stopping web driver");
    }
}