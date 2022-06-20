using Allure.Net.Examples.xUnit.Tests.Library.CustomAttributes;
using Allure.Net.Examples.xUnit.Tests.Library.TestSteps;
using Allure.Xunit.Attributes;
using Xunit;

namespace Allure.Net.Examples.xUnit.Tests;

[Layer("web")]
[AllureOwner("neparij")]
[AllureFeature("Pull Requests")]
[AllureSuite("PR Web")]
public class PullRequestsWebTest : IAsyncLifetime
{
    private const string Owner = "allure-framework";
    private const string Repo = "allure2";
    private const string Branch = "new-feature";

    public Task InitializeAsync()
    {
        return WebSteps.StartDriver();
    }

    /**
     * <summary>
     * Test with multiple Issues
     * TODO: Contribute/Feature request to Allure.Xunit: Allow multiple Issues linking 
     * </summary>
     */
    [Tm4J("AE-T6")]
    [Microservice("Billing")]
    [AllureStory("Create new pull request")]
    [AllureTag("web", "regress", "smoke")]
    [AllureIssue("jira", "AE-1")]
    // [AllureIssue("jira", "AE-2")] <- this line will broke compilation due to multiple attribute usage restriction
    [AllureXunit(DisplayName = "Creating new issue for authorized user")]
    public async Task ShouldCreatePullRequest()
    {
        await WebSteps.OpenPullRequestsPage(Owner, Repo);
        WebSteps.CreatePullRequestFromBranch(Branch);
        WebSteps.ShouldSeePullRequestForBranch(Branch);
    }
    
    [Tm4J("AE-T7")]
    [AllureIssue("jira", "AE-2")]
    [Microservice("Repository")]
    [AllureStory("Close existing pull request")]
    [AllureTag("web", "regress")]
    [AllureXunit(DisplayName = "Deleting existing issue for authorized user")]
    public async Task ShouldClosePullRequest() {
        await WebSteps.OpenPullRequestsPage(Owner, Repo);
        WebSteps.CreatePullRequestFromBranch(Branch);
        WebSteps.ClosePullRequestForBranch(Branch);
        WebSteps.ShouldNotSeePullRequestForBranch(Branch);
    }

    public Task DisposeAsync()
    {
        return WebSteps.StopDriver();
    }
}