using System;
using Allure.Xunit.Attributes;

namespace Allure.Net.Examples.xUnit.Tests.Library.CustomAttributes
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class)]
    public class MicroserviceAttribute : AllureLabelAttribute
    {
        public MicroserviceAttribute(string value) : base("msrv", value)
        {
        }
    }
}