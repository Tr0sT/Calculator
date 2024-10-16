#nullable enable
using R3;

namespace Calculator.Views
{
    public interface ICalculatorWindow
    {
        Observable<string> OnInputChanged { get; }
        Observable<Unit> OnSubmit { get; }
        void SetInputText(string text);
        HistoryLineView AddHistoryItem();
    }
}