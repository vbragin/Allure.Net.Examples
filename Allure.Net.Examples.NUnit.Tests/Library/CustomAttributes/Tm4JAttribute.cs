using System;
using NUnit.Allure.Attributes;

namespace Allure.Net.Examples.NUnit.Tests.Library.CustomAttributes
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class)]
    public class Tm4JAttribute : AllureLabelAttribute
    {
        public Tm4JAttribute(string value) : base("tm4j", value)
        {
        }
    }
}