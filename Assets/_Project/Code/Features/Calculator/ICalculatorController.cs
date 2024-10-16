#nullable enable
using System.Collections.ObjectModel;

namespace Calculator.Features
{
    public interface ICalculatorController
    {
        InputString CurrentInput { get; }
        ReadOnlyCollection<HistoryItem> History { get; }
        
        void OpenCalculatorWindow();
        void SetCurrentInput(InputString value);
        CalculationResult CalculateResultAndPopulateHistory(InputString value);
    }
}