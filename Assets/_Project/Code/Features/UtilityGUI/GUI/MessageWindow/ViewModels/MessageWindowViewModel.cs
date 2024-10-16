#nullable enable
namespace Calculator.ViewModels
{
    public class MessageWindowViewModel : IMessageWindowViewModel
    {
        public MessageWindowViewModel(MessageWindowData data)
        {
            Message = data.Message;
        }

        public string Message { get; }
    }
}