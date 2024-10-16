#nullable enable
using R3;
using UnityEngine;
using UnityEngine.UI;

namespace Calculator.Views
{
    public sealed class CalculatorWindow : MonoBehaviour, ICalculatorWindow
    {
        [SerializeField] private InputField _inputField = null!;
        [SerializeField] private RectTransform _historyContainer = null!;
        [SerializeField] private HistoryLineView _historyLinePrefab = null!;
        
        private readonly Subject<Unit> _onSubmit = new();
        private readonly Subject<string> _onInputChanged = new();

        private void Awake()
        {
            _inputField.OnValueChangedAsObservable().Skip(1)
                .Subscribe(_ => _onInputChanged.OnNext(_inputField.text)).AddTo(gameObject);
        }

        private void OnDestroy()
        {
            _onSubmit.Dispose();
            _onInputChanged.Dispose();
        }

        public void OnSubmitButtonClick() => _onSubmit.OnNext(Unit.Default);

        public Observable<string> OnInputChanged => _onInputChanged;
        public Observable<Unit> OnSubmit => _onSubmit;
        public void SetInputText(string text)
        {
            _inputField.SetTextWithoutNotify(text);
        }

        public HistoryLineView AddHistoryItem()
        {
            return Instantiate(_historyLinePrefab, _historyContainer);
        }
    }
}