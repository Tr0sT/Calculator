#nullable enable
using Calculator.Features;
using Calculator.Views;

namespace Calculator.Presenters
{
    public sealed class HistoryLinePresenter
    {
        public HistoryLinePresenter(IHistoryItem value, HistoryLineView historyLineView)
        {
            var result = value.Result.IsValid() ? value.Result.Value.ToString() : "ERROR";
            historyLineView.Init($"{value.Input.Value}={result}");
        }
    }
}