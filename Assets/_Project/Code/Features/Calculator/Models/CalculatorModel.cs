#nullable enable
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Calculator.Features
{
    public sealed class CalculatorModel : ICalculatorModel
    {
        private readonly List<HistoryItem> _history;

        public CalculatorModel(CalculatorData? data)
        {
            if (data == null)
            {
                CurrentInput = new(string.Empty);
                _history = new();
            }
            else
            {
                CurrentInput = new(data.CurrentInput);
                _history = data.History
                    .Select(historyData => new HistoryItem(
                        new InputString(historyData.Input), 
                        new CalculationResult(historyData.Result)))
                    .ToList();
            }
        }
        
        public InputString CurrentInput { get; private set; }
        public ReadOnlyCollection<HistoryItem> History => _history.AsReadOnly();

        public void PopulateHistory(HistoryItem historyItem)
        {
            _history.Add(historyItem);
        }

        public void SetCurrentInput(InputString value)
        {
            CurrentInput = value;
        }

        public CalculatorData ToData()
        {
            return new CalculatorData
            {
                CurrentInput = CurrentInput.Value,
                History = _history.Select(h => h.ToData()).ToList()
            };
        }
    }
}