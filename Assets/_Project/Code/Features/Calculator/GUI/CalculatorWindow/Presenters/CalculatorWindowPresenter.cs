#nullable enable
using System;
using System.Linq;
using Calculator.Features;
using Calculator.Views;
using Nuclear.Services;
using R3;

namespace Calculator.Presenters
{
    public sealed class CalculatorWindowPresenter : IDisposable
    {
        private readonly IWindowsService _windowsService;
        private readonly ICalculatorController _controller;
        private readonly ICalculatorWindow _calculatorWindow;
        private readonly CompositeDisposable _disposables = new CompositeDisposable();

        public CalculatorWindowPresenter(IWindowsService windowsService, ICalculatorController controller,
            ICalculatorWindow calculatorWindow)
        {
            _windowsService = windowsService;
            _controller = controller;
            _calculatorWindow = calculatorWindow;

            _calculatorWindow.SetInputText(_controller.CurrentInput.Value);
            foreach (var historyItem in _controller.History)
            {
                AddHistoryLine(historyItem);
            }

            _calculatorWindow.OnSubmit.Subscribe(_ => HandleSubmitButtonClick()).AddTo(_disposables);
            _calculatorWindow.OnInputChanged.Subscribe(HandleInputValueChanged).AddTo(_disposables);
        }

        public void Dispose()
        {
            _disposables.Dispose();
        }

        private void AddHistoryLine(HistoryItem historyItem)
        {
            var historyLine = _calculatorWindow.AddHistoryItem();
            var historyLinePresenter = new HistoryLinePresenter(historyItem, historyLine);
        }

        private void HandleInputValueChanged(string value)
        {
            _controller.SetCurrentInput(new (value));
        }

        private void HandleSubmitButtonClick()
        {
            var result = _controller.CalculateResultAndPopulateHistory(_controller.CurrentInput);
            AddHistoryLine(_controller.History.Last());
            
            if (!result.Value.HasValue)
            {
                _windowsService.ShowMessageWindow("Please check the expression you just entered");
            }
            else
            {
                _calculatorWindow.SetInputText("");
            }
        }
    }
}