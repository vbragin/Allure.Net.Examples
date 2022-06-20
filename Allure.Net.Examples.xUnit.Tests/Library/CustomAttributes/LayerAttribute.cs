using Allure.Xunit.Attributes;

namespace Allure.Net.Examples.xUnit.Tests.Library.CustomAttributes;

[AttributeUsage(AttributeTargets.Method | AttributeTargets.Class)]
public class LayerAttribute : AllureLabelAttribute
{
    public LayerAttribute(string value) : base("layer", value)
    {
    }
}