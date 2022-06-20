using NUnit.Allure.Attributes;

namespace Allure.Net.Examples.NUnit.Tests.Library.CustomAttributes;

[AttributeUsage(AttributeTargets.Method | AttributeTargets.Class)]
public class MicroserviceAttribute : AllureLabelAttribute
{
    public MicroserviceAttribute(string value) : base("msrv", value)
    {
    }
}