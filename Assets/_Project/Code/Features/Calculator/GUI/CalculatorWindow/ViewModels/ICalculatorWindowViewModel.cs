#nullable enable
using System.Collections.ObjectModel;
using Nuclear.Services;
using R3;

namespace Calculator.ViewModels
{
    public interface ICalculatorWindowViewModel : IViewModel
    {
        Observable<IHistoryLineViewModel> OnAddHistoryLine { get; }
        Observable<Unit> OnResetInputLine { get; }
        string StartInputText { get; }
        ReadOnlyCollection<IHistoryLineViewModel> StartHistoryLineViewModels { get; }
        void HandleInputValueChanged(string value);
        void HandleSubmitButtonClick();
    }
}