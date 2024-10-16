#nullable enable
using Calculator.ViewModels;
using Nuclear.Services;
using Nuclear.Services.GUI;
using R3;
using UnityEngine;
using UnityEngine.UI;

namespace Calculator.Views
{
    [Path("GUI/CalculatorWindow/CalculatorWindow")]
    public sealed class CalculatorWindow : MWindow<ICalculatorWindowViewModel>
    {
        [SerializeField] private InputField _inputField = null!;
        [SerializeField] private RectTransform _historyContainer = null!;
        [SerializeField] private HistoryLineView _historyLinePrefab = null!;
        
        public override void Init()
        {
            base.Init();
            _inputField.SetTextWithoutNotify(_viewModel.StartInputText);
            _inputField.OnValueChangedAsObservable().Skip(1).Subscribe(_viewModel.HandleInputValueChanged).AddTo(gameObject);

            foreach (var historyLineViewModel in _viewModel.StartHistoryLineViewModels)
            {
                CreateHistoryLine(historyLineViewModel);
            }

            _viewModel.OnAddHistoryLine.Subscribe(CreateHistoryLine).AddTo(gameObject);
            _viewModel.OnResetInputLine.Subscribe(_ => _inputField.SetTextWithoutNotify("")).AddTo(gameObject);
        }

        private void CreateHistoryLine(IHistoryLineViewModel historyLineViewModel)
        {
            var line = Instantiate(_historyLinePrefab, _historyContainer);
            line.Init(historyLineViewModel);
        }

        public void OnSubmitButtonClick()
        {
            _viewModel.HandleSubmitButtonClick();
        }
    }
}