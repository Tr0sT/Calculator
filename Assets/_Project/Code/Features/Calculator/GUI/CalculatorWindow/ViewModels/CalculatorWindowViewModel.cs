#nullable enable
using System.Collections.ObjectModel;
using System.Linq;
using JetBrains.Annotations;
using Calculator.Features;
using Calculator.Views;
using Nuclear.Services;
using R3;

namespace Calculator.ViewModels
{
    [UsedImplicitly]
    public sealed class CalculatorWindowViewModel : ICalculatorWindowViewModel
    {
        private readonly IWindowsService _windowsService;
        private readonly ICalculatorController _controller;
        private readonly Subject<IHistoryLineViewModel> _onAddHistoryLine = new();
        private readonly Subject<Unit> _onResetInputLine = new ();

        public CalculatorWindowViewModel(IWindowsService windowsService, ICalculatorController controller)
        {
            _windowsService = windowsService;
            _controller = controller;
            StartInputText = _controller.CurrentInput.Value;
            StartHistoryLineViewModels = _controller.History
                .Select(h => (IHistoryLineViewModel)new HistoryLineViewModel(h))
                .ToList().AsReadOnly();
        }

        public Observable<Unit> OnResetInputLine => _onResetInputLine;
        public Observable<IHistoryLineViewModel> OnAddHistoryLine => _onAddHistoryLine;
        public string StartInputText { get; }
        public ReadOnlyCollection<IHistoryLineViewModel> StartHistoryLineViewModels { get; }

        public void HandleInputValueChanged(string value)
        {
            _controller.SetCurrentInput(new (value));
        }

        public void HandleSubmitButtonClick()
        {
            var result = _controller.CalculateResultAndPopulateHistory(_controller.CurrentInput);
            _onAddHistoryLine.OnNext(new HistoryLineViewModel(_controller.History.Last()));
            if (!result.Value.HasValue)
            {
                _windowsService.CreateWindow<MessageWindow, IMessageWindowViewModel, MessageWindowData>(
                    new("Please check the expression you just entered"));
            }
            else
            {
                _onResetInputLine.OnNext(Unit.Default);
            }
        }
    }
}