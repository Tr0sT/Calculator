#nullable enable
using R3;
using UnityEngine;
using UnityEngine.UI;

namespace Calculator.Views
{
    public class MessageWindow : MonoBehaviour, IMessageWindow
    {
        [SerializeField] private Text _messageText = null!;
        private readonly Subject<Unit> _onClose = new();

        public Observable<Unit> OnClose => _onClose;

        void IMessageWindow.Init(string text)
        {
            gameObject.SetActive(true);
            _messageText.text = text;
        }

        void IMessageWindow.Close() => gameObject.SetActive(false);
        public void OnOkClick() => _onClose.OnNext(Unit.Default);
    }
}