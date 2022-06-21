using System;
using System.IO;
using System.Threading;
using Allure.Commons;
using NUnit.Allure.Attributes;
using NUnit.Framework;

namespace Allure.Net.Examples.NUnit.Tests.Library.TestSteps
{
    public static class WebSteps
    {
        private static readonly Random Random = new();

        /**
         * <summary>
         *     Step used in SetUp method.
         *     Currently there is no way to use AllureStepAttribute here. It will broke your code
         *     TODO: rework step extension
         * </summary>
         */
        // [AllureStep("Starting web driver")] <- broke testrun as well
        public static void StartDriver()
        {
            MaybeThrowSeleniumTimeoutException();
        }

        /**
         * <summary>
         *     Step used in TearDown method.
         *     Currently there is no way to use AllureStepAttribute here.
         *     <see cref="IssuesWebTest.TearDownOnce">Workaround</see>.
         *     TODO: rework step extension
         * </summary>
         */
        [AllureStep("Stopping web driver")] // <- it doesn't make any sense
        public static void StopDriver()
        {
            MaybeThrowSeleniumTimeoutException();
        }

        [AllureStep("Open issues page `{0}/{1}`")]
        public static void OpenIssuesPage(string owner, string repo)
        {
            AttachPageSource();
            MaybeThrowElementNotFoundException();
        }

        [AllureStep("Open pull requests page `{0}/{1}`")]
        public static void OpenPullRequestsPage(string owner, string repo)
        {
            AttachPageSource();
            MaybeThrowElementNotFoundException();
        }


        [AllureStep("Create pull request from branch `{0}`")]
        public static void CreatePullRequestFromBranch(string branch)
        {
            MaybeThrowElementNotFoundException();
        }

        [AllureStep("Create issue with title `{0}`")]
        public static void CreateIssueWithTitle(string title)
        {
            MaybeThrowAssertionException(title);
        }

        [AllureStep("Close pull request for branch `{0}`")]
        public static void ClosePullRequestForBranch(string branch)
        {
            MaybeThrowAssertionException(branch);
        }

        [AllureStep("Close issue with title `{0}`")]
        public static void CloseIssueWithTitle(string title)
        {
            MaybeThrowAssertionException(title);
        }

        [AllureStep("Check pull request for branch `{0}` exists")]
        public static void ShouldSeePullRequestForBranch(string branch)
        {
            MaybeThrowAssertionException(branch);
        }

        [AllureStep("Check issue with title `{0}` exists")]
        public static void ShouldSeeIssueWithTitle(string title)
        {
            MaybeThrowAssertionException(title);
        }

        [AllureStep("Check pull request for branch `{0}` not exists")]
        public static void ShouldNotSeePullRequestForBranch(string branch)
        {
            MaybeThrowAssertionException(branch);
        }

        [AllureStep("Check issue with title `{0}` not exists")]
        public static void ShouldNotSeeIssueWithTitle(string title)
        {
            MaybeThrowAssertionException(title);
        }

        private static void AttachPageSource()
        {
            AllureLifecycle.Instance.AddAttachment(
                Path.Combine(TestContext.CurrentContext.TestDirectory, "index.html"),
                "index.html");
        }

        private static void MaybeThrowSeleniumTimeoutException()
        {
            if (IsTimeToThrowException()) Assert.Fail(WebDriverIsNotReachableMessage("Allure"));
        }

        private static void MaybeThrowElementNotFoundException()
        {
            Thread.Sleep(1000);
            if (IsTimeToThrowException()) Assert.Fail(ElementNotFoundMessage("[//div[@class='something']]"));
        }

        private static void MaybeThrowAssertionException(string text)
        {
            if (IsTimeToThrowException())
                Assert.Fail(TextEqualMessage(text, "another text"));
            else
                Assert.That(text, Is.EqualTo(text));
        }

        private static bool IsTimeToThrowException()
        {
            return Random.Next(0, 4) == 0;
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
}