using NUnit.Allure.Attributes;

namespace Allure.Net.Examples.NUnit.Tests.Library.CustomAttributes;

[AttributeUsage(AttributeTargets.Method | AttributeTargets.Class)]
public class LayerAttribute : AllureLabelAttribute
{
    public LayerAttribute(string value) : base("layer", value)
    {
    }
}