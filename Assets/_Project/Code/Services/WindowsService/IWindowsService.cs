#nullable enable
using Nuclear.Services.GUI;

namespace Nuclear.Services
{
    public interface IWindowsService
    {
        TWindow CreateWindow<TWindow, TViewModel, TViewModelData>(TViewModelData data)
            where TWindow : MWindow<TViewModel>
            where TViewModel : IViewModel;

        TWindow CreateWindow<TWindow, TViewModel>()
            where TWindow : MWindow<TViewModel>
            where TViewModel : IViewModel;
    }
}