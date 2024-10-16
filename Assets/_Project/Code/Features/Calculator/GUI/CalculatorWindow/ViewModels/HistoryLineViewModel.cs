#nullable enable
using Calculator.Features;

namespace Calculator.ViewModels
{
    public sealed class HistoryLineViewModel : IHistoryLineViewModel
    {
        public HistoryLineViewModel(IHistoryItem value)
        {
            var result = value.Result.IsValid() ? value.Result.Value.ToString() : "ERROR";
            Text = $"{value.Input.Value}={result}";
        }
        public string Text { get; }
    }
}