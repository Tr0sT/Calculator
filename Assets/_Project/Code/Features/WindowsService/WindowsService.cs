#nullable enable
using Calculator.Presenters;
using Calculator.Views;

namespace Nuclear.Services
{
    public sealed class WindowsService : IWindowsService
    {
        private readonly MessageWindow _messageWindow;
        private readonly CalculatorWindow _calculatorWindow;

        public WindowsService(MessageWindow messageWindow, CalculatorWindow calculatorWindow)
        {
            _messageWindow = messageWindow;
            _calculatorWindow = calculatorWindow;
            
        }

        public ICalculatorWindow GetCalculatorWindow()
        {
            _calculatorWindow.gameObject.SetActive(true);
            return _calculatorWindow;
        }

        public void ShowMessageWindow(string message)
        {
            var messageWindowPresenter = new MessageWindowPresenter(_messageWindow, message);
        }
    }
}