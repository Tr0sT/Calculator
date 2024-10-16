#nullable enable
using System;
using Calculator.Views;
using R3;

namespace Calculator.Presenters
{
    public sealed class MessageWindowPresenter : IDisposable
    {
        private readonly CompositeDisposable _disposables = new();

        public MessageWindowPresenter(IMessageWindow messageWindow, string message)
        {
            messageWindow.Init(message);
            messageWindow.OnClose.Subscribe(_ =>
            {
                messageWindow.Close();
                Dispose();
            }).AddTo(_disposables);
        }

        public void Dispose()
        {
            _disposables.Dispose();
        }
    }
}