using Allure.Xunit;
using Allure.Xunit.StepAttribute;

namespace Allure.Net.Examples.xUnit.Tests.Library.TestSteps;

public static class RestSteps
{
    /**
     * <summary>
     * Named step with nested step inside.
     * Arguments cannot be used in step definition yet. <see cref="ShouldSeeIssueWithTitle">Workaround</see>.
     * TODO: Contribute/Feature request to Allure.Xunit: arguments should be passed to Step definition (using MethodBoundaryAspect Fody plugin)
     * </summary>
     */
    [AllureStep("Create issue with title {title}")]
    public static void CreateIssueWithTitle(string owner, [Name("repository")] string repo, string title)
    {
        Steps.Step($"POST /repos/{owner}/{repo}/issues");
    }

    public static void ShouldSeeIssueWithTitle(string owner, [Name("repository")] string repo, string title)
    {
        Steps.Step($"Check note with content `{title}` exists", () =>
        {
            Steps.Step($"GET /repos/{owner}/{repo}/issues?text={title}");
            Steps.Step($"GET /repos/{owner}/{repo}/issues/10");
        });
    }
    
    public static void CloseIssueWithTitle(string owner, [Name("repository")] string repo, string title)
    {
        Steps.Step($"Check note with content `{title}` exists", () =>
        {
            Steps.Step($"GET /repos/{owner}/{repo}/issues?text={title}");
            Steps.Step($"PATCH /repos/{owner}/{repo}/issues/10");
        });
    }
}