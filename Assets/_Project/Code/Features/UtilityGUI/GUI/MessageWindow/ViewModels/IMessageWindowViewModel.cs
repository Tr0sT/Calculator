#nullable enable
using Nuclear.Services;

namespace Calculator.ViewModels
{
    public interface IMessageWindowViewModel : IViewModel
    {
        string Message { get; }
    }
}