#nullable enable
using System.Collections.ObjectModel;
using JetBrains.Annotations;
using Calculator.ViewModels;
using Calculator.Views;
using Nuclear.Services;

namespace Calculator.Features
{
    [UsedImplicitly]
    public sealed class CalculatorController : ICalculatorController
    {
        private readonly IWindowsService _windowsService;
        private readonly ISaveProvider _saveProvider;

        private readonly CalculatorModel _calculatorModel;

        public CalculatorController(IWindowsService windowsService, 
            ISaveProvider saveProvider)
        {
            _windowsService = windowsService;
            _saveProvider = saveProvider;
            _saveProvider.RegisterSave(Save);

            var data = _saveProvider.Data.CalculatorData;
            _calculatorModel = new CalculatorModel(data);
        }

        private void Save()
        {
            _saveProvider.Data.CalculatorData = _calculatorModel.ToData();
        }

        public InputString CurrentInput => _calculatorModel.CurrentInput;
        public ReadOnlyCollection<HistoryItem> History => _calculatorModel.History;

        public void OpenCalculatorWindow() => _windowsService.CreateWindow<CalculatorWindow, ICalculatorWindowViewModel>();
        public CalculationResult CalculateResultAndPopulateHistory(InputString value)
        {
            var result = CalculatorHelper.ParseAndCalculateResult(value);
            _calculatorModel.PopulateHistory(new HistoryItem(value, result));
            if (result.IsValid())
            {
                _calculatorModel.SetCurrentInput(new(""));
            }
            return result;
        }

        public void SetCurrentInput(InputString value)
        {
            _calculatorModel.SetCurrentInput(value);
        }
    }
}