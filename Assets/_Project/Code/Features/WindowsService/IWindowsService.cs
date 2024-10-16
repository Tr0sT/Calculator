#nullable enable
using Calculator.Views;

namespace Nuclear.Services
{
    public interface IWindowsService
    {
        ICalculatorWindow GetCalculatorWindow();
        void ShowMessageWindow(string message);
    }
}