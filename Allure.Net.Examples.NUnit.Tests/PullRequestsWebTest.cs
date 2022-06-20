using Allure.Net.Examples.NUnit.Tests.Library.CustomAttributes;
using Allure.Net.Examples.NUnit.Tests.Library.TestSteps;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;

namespace Allure.Net.Examples.NUnit.Tests;

[Layer("web")]
[AllureOwner("neparij")]
[AllureFeature("Pull Requests")]
[AllureSuite("PR Web")]
[AllureNUnit]
public class PullRequestsWebTest
{
    private const string Owner = "allure-framework";
    private const string Repo = "allure2";
    private const string Branch = "new-feature";

    [OneTimeSetUp]
    public void SetUpOnce()
    {
        WebSteps.StartDriver();
    }

    [Test]
    [Tm4J("AE-T6")]
    [Microservice("Billing")]
    [AllureStory("Create new pull request")]
    [AllureTag("web", "regress", "smoke")]
    [AllureIssue("jira", "AE-1")]
    [AllureIssue("jira", "AE-2")]
    [AllureName("Creating new issue for authorized user")]
    public void ShouldCreatePullRequest()
    {
        WebSteps.OpenPullRequestsPage(Owner, Repo);
        WebSteps.CreatePullRequestFromBranch(Branch);
        WebSteps.ShouldSeePullRequestForBranch(Branch);
    }
    
    [Test]
    [Tm4J("AE-T7")]
    [AllureIssue("jira", "AE-2")]
    [Microservice("Repository")]
    [AllureStory("Close existing pull request")]
    [AllureTag("web", "regress")]
    [AllureName("Deleting existing issue for authorized user")]
    public void ShouldClosePullRequest() {
        WebSteps.OpenPullRequestsPage(Owner, Repo);
        WebSteps.CreatePullRequestFromBranch(Branch);
        WebSteps.ClosePullRequestForBranch(Branch);
        WebSteps.ShouldNotSeePullRequestForBranch(Branch);
    }

    [OneTimeTearDown]
    public void TearDownOnce()
    {
        WebSteps.StopDriver();
    }
}