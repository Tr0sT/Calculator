#nullable enable
using System.Reflection;
using JetBrains.Annotations;
using Nuclear.Services.GUI;
using Nuclear.WindowsManager;
using VContainer.Unity;

namespace Nuclear.Services
{
    [UsedImplicitly]
    public class WindowsService : IWindowsService
    {
        private readonly IWindowsManager _mainWindowsManager;
        private readonly IViewModelFactory _viewModelFactory;
        private readonly IObjectResolverProvider _objectResolverProvider;

        public WindowsService(IWindowsManager mainWindowsManager, 
            IViewModelFactory viewModelFactory, 
            IObjectResolverProvider objectResolverProvider 
            )
        {
            _mainWindowsManager = mainWindowsManager;
            _viewModelFactory = viewModelFactory;
            _objectResolverProvider = objectResolverProvider;
        }

        public TWindow CreateWindow<TWindow, TViewModel, TViewModelData>(TViewModelData data) 
            where TWindow : MWindow<TViewModel> 
            where TViewModel : IViewModel 
        {
            return (TWindow)_mainWindowsManager.CreateWindow(GetPath(typeof(TWindow)),
                window =>
                {
                    var tWindow = (MWindow<TViewModel>) window;
                    _objectResolverProvider.Container.InjectGameObject(tWindow.gameObject);
                    var tViewModel = _viewModelFactory.Create<TViewModel, TViewModelData>(data);
                    tWindow.SetViewModel(tViewModel);
                });
        }

        public TWindow CreateWindow<TWindow, TViewModel>() 
            where TWindow : MWindow<TViewModel> 
            where TViewModel : IViewModel
        {
            return (TWindow)_mainWindowsManager.CreateWindow(GetPath(typeof(TWindow)),
                window =>
                {
                    var tWindow = (MWindow<TViewModel>) window;
                    _objectResolverProvider.Container.InjectGameObject(tWindow.gameObject);
                    var tViewModel = _viewModelFactory.Create<TViewModel>();
                    tWindow.SetViewModel(tViewModel);
                });
        }

        private static string GetPath(MemberInfo type)
        {
            var attribute = type.GetCustomAttribute<PathAttribute>(inherit: true);
            if (attribute == null)
            {
                throw new($"No Path attribute for type {type.Name}");
            }
            
            return attribute.Path;
        }
    }
}