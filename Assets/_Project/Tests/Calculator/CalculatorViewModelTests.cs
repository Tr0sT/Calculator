#nullable enable
using System.Collections.Generic;
using Calculator.Features;
using Calculator.ViewModels;
using Moq;
using NUnit.Framework;
using Assert = UnityEngine.Assertions.Assert;

namespace Calculator.Tests
{
   public sealed class CalculatorViewModelTests
    {
        [Test]
        public void Test1()
        {
            const string input = "5+";
            var history1 = new InputString("5+5");
            var history2 = new InputString("5-5");
            var calculatorControllerMock = new Mock<ICalculatorController>();
            calculatorControllerMock.Setup(c => c.CurrentInput).Returns(new InputString(input));
            calculatorControllerMock.Setup(c => c.History).Returns(
                new List<HistoryItem>
                {
                    new HistoryItem(history1, CalculatorHelper.ParseAndCalculateResult(history1)),
                    new HistoryItem(history2, CalculatorHelper.ParseAndCalculateResult(history2))
                }.AsReadOnly);
            
            var viewModel = new CalculatorWindowViewModel(null!, calculatorControllerMock.Object);
            Assert.AreEqual(viewModel.StartInputText, input);
            Assert.AreEqual(viewModel.StartHistoryLineViewModels.Count, 2);
            Assert.AreEqual(viewModel.StartHistoryLineViewModels[0].Text, "5+5=10");
            Assert.AreEqual(viewModel.StartHistoryLineViewModels[1].Text, "5-5=ERROR");
        }
    }
}