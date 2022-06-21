using System;
using Allure.Xunit.Attributes;

namespace Allure.Net.Examples.xUnit.Tests.Library.CustomAttributes
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class)]
    public class Tm4JAttribute : AllureLabelAttribute
    {
        public Tm4JAttribute(string value) : base("tm4j", value)
        {
        }
    }
}