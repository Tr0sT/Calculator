#nullable enable
using Calculator.Features;
using NUnit.Framework;

namespace Calculator.Tests
{
   public sealed class CalculatorInputParserTests
    {
        [Test]
        public void Test1()
        {
            var result = CalculatorHelper.ParseAndCalculateResult(new ("54+21"));
            Assert.AreEqual(result.IsValid(), true);
            Assert.AreEqual(result.Value!.Value, 54+21);
            
            result = CalculatorHelper.ParseAndCalculateResult(new ("45+00"));
            Assert.AreEqual(result.IsValid(), true);
            Assert.AreEqual(result.Value!.Value, 45);
            
            result = CalculatorHelper.ParseAndCalculateResult(new ("45+-88"));
            Assert.AreEqual(result.IsValid(), false);
            
            result = CalculatorHelper.ParseAndCalculateResult(new ("98.12+48.1"));
            Assert.AreEqual(result.IsValid(), false);
        }
    }
}