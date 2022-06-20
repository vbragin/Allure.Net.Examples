using Allure.Commons;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;

namespace Allure.Net.Examples.NUnit.Tests.Library.TestSteps;

public static class RestSteps
{
    [AllureStep("Create issue with title {2}")]
    public static void CreateIssueWithTitle(string owner, string repo, string title)
    {
        AllureLifecycle.Instance.WrapInStep(() =>{}, $"POST /repos/{owner}/{repo}/issues");
    }

    [AllureStep("Check note with content `{2}` exists")]
    public static void ShouldSeeIssueWithTitle(string owner, string repo, string title)
    {
        AllureLifecycle.Instance.WrapInStep(() =>{}, $"GET /repos/{owner}/{repo}/issues?text={title}");
        AllureLifecycle.Instance.WrapInStep(() =>{}, $"GET /repos/{owner}/{repo}/issues/10");
    }

    [AllureStep("Check note with content `{2}` exists")]
    public static void CloseIssueWithTitle(string owner, string repo, string title)
    {
        AllureLifecycle.Instance.WrapInStep(() =>{}, $"GET /repos/{owner}/{repo}/issues?text={title}");
        AllureLifecycle.Instance.WrapInStep(() =>{}, $"PATCH /repos/{owner}/{repo}/issues/10");
    }
}