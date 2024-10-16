#nullable enable
using System;
using Nuclear.WindowsManager;

namespace Nuclear.Services.GUI
{
    public abstract class MWindow<TViewModel> : Window where TViewModel : IViewModel
    {
        protected TViewModel _viewModel = default!;
        public void SetViewModel(TViewModel viewModel)
        {
            _viewModel = viewModel;
            if (_viewModel is IDisposable disposable)
                AddDeInitAction(disposable.Dispose);
        }
    }
}
