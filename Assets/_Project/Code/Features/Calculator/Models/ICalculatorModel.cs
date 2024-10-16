#nullable enable
using System.Collections.ObjectModel;

namespace Calculator.Features
{
    public interface ICalculatorModel
    {
        public InputString CurrentInput { get; }
        public ReadOnlyCollection<HistoryItem> History { get; }
    }
}