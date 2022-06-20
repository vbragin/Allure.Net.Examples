using Allure.XUnit;
using Allure.Xunit.StepAttribute;
using Xunit;

namespace Allure.Net.Examples.xUnit.Tests.Library.TestSteps;

public static class WebSteps
{
    [AllureStep("Starting web driver")]
    public static Task StartDriver()
    {
        MaybeThrowSeleniumTimeoutException();
        return Task.CompletedTask;
    }

    [AllureStep("Stopping web driver")]
    public static Task StopDriver()
    {
        MaybeThrowSeleniumTimeoutException();
        return Task.CompletedTask;
    }

    [AllureStep("Open issues page `{owner}/{repo}`")]
    public static async Task OpenIssuesPage(string owner, string repo)
    {
        await AttachPageSource();
        MaybeThrowElementNotFoundException();
    }

    [AllureStep("Open pull requests page `{owner}/{repo}`")]
    public static async Task OpenPullRequestsPage(string owner, string repo)
    {
        await AttachPageSource();
        MaybeThrowElementNotFoundException();
    }


    [AllureStep("Create pull request from branch `{branch}`")]
    public static void CreatePullRequestFromBranch(string branch)
    {
        MaybeThrowElementNotFoundException();
    }

    [AllureStep("Create issue with title `{title}`")]
    public static void CreateIssueWithTitle(string title)
    {
        MaybeThrowAssertionException(title);
    }

    [AllureStep("Close pull request for branch `{branch}`")]
    public static void ClosePullRequestForBranch(string branch)
    {
        MaybeThrowAssertionException(branch);
    }

    [AllureStep("Close issue with title `{title}`")]
    public static void CloseIssueWithTitle(string title)
    {
        MaybeThrowAssertionException(title);
    }

    [AllureStep("Check pull request for branch `{branch}` exists")]
    public static void ShouldSeePullRequestForBranch(string branch)
    {
        MaybeThrowAssertionException(branch);
    }

    [AllureStep("Check issue with title `{title}` exists")]
    public static void ShouldSeeIssueWithTitle(string title)
    {
        MaybeThrowAssertionException(title);
    }

    [AllureStep("Check pull request for branch `{branch}` not exists")]
    public static void ShouldNotSeePullRequestForBranch(string branch)
    {
        MaybeThrowAssertionException(branch);
    }

    [AllureStep("Check issue with title `{title}` not exists")]
    public static void ShouldNotSeeIssueWithTitle(string title)
    {
        MaybeThrowAssertionException(title);
    }

    private static async Task AttachPageSource()
    {
        await AllureAttachments.File("index.html", @"./index.html");
    }

    private static void MaybeThrowSeleniumTimeoutException()
    {
        if (IsTimeToThrowException())
        {
            Assert.True(false, WebDriverIsNotReachableMessage("Allure"));
        }
    }

    private static void MaybeThrowElementNotFoundException()
    {
        Thread.Sleep(1000);
        if (IsTimeToThrowException())
        {
            Assert.True(false, ElementNotFoundMessage("[//div[@class='something']]"));
        }
    }

    private static void MaybeThrowAssertionException(string text)
    {
        if (IsTimeToThrowException())
        {
            Assert.True(false, TextEqualMessage(text, "another text"));
        }
        else
        {
            Assert.Equal(text, text);
        }
    }

    private static bool IsTimeToThrowException()
    {
        return Random.Shared.Next(0, 4) == 0;
    }

    private static string WebDriverIsNotReachableMessage(string text)
    {
        return "WebDriverException: chrome not reachable\n" +
               "Element not found {By.xpath: //a[@href='/eroshenkoam/allure-example']}\n" +
               $"Expected: text {text}\n" +
               "Page source: file:/Users/eroshenkoam/Developer/eroshenkoam/webdriver-coverage-example/build/reports/tests/1603973861960.0.html\n" +
               "Timeout: 4 s.\n";
    }

    private static string TextEqualMessage(string expected, string actual)
    {
        return $"Element should text {expected} {{By.xpath: //a[@href='/eroshenkoam/allure-example']}}\n" +
               $"Element: '<a class=\"v-align-middle\">{actual}</a>'\n" +
               "Screenshot: file:/Users/eroshenkoam/Developer/eroshenkoam/webdriver-coverage-example/build/reports/tests/1603973703632.0.png\n" +
               "Page source: file:/Users/eroshenkoam/Developer/eroshenkoam/webdriver-coverage-example/build/reports/tests/1603973703632.0.html\n" +
               "Timeout: 4 s.\n";
    }

    private static string ElementNotFoundMessage(string selector)
    {
        return $"Element not found {{By.xpath: {selector}\n" +
               "Expected: visible or transparent: visible or have css value opacity=0\n" +
               "Screenshot: file:/Users/eroshenkoam/Developer/eroshenkoam/webdriver-coverage-example/build/reports/tests/1603973516437.0.png\n" +
               "Page source: file:/Users/eroshenkoam/Developer/eroshenkoam/webdriver-coverage-example/build/reports/tests/1603973516437.0.html\n" +
               "Timeout: 4 s.\n";
    }
}