#nullable enable
using R3;

namespace Calculator.Views
{
    public interface IMessageWindow
    {
        Observable<Unit> OnClose { get; }
        void Init(string text);
        void Close();
    }
}