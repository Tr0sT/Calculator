#nullable enable
using Calculator.Services;
using Calculator.ViewModels;
using Nuclear.Services;
using Nuclear.WindowsManager;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Calculator.Features
{
    public static class DIContainer
    {
        private static LifetimeScope _rootLifetimeScope = null!;
        private static UnityProvider _unityProvider = null!;

        public static IObjectResolver Init(Transform transform)
        {
            _unityProvider = transform.gameObject.AddComponent<UnityProvider>();
            
            var vcontainerSettings = VContainerSettings.Instance;
            var root = new GameObject("RootLifetimeScope");
            root.transform.SetParent(transform);
            _rootLifetimeScope = root.AddComponent<LifetimeScope>();
            vcontainerSettings.RootLifetimeScope = _rootLifetimeScope;
            
            var lifetimeScope = VContainerSettings.Instance.GetOrCreateRootLifetimeScopeInstance();
            lifetimeScope = lifetimeScope.CreateChild(Install);
            return lifetimeScope.Container;
        }

        private static void Install(IContainerBuilder builder)
        {
            builder.Register<ObjectResolverProvider>(Lifetime.Singleton).AsImplementedInterfaces().AsSelf();
            
            RegisterWindowsService(builder);

            builder.RegisterInstance<IUnityProvider>(_unityProvider);
            
            builder.Register<SaveLoadService>(Lifetime.Singleton).AsImplementedInterfaces();
            
            builder.Register<SaveProvider>(Lifetime.Singleton).AsImplementedInterfaces();
            builder.Register<CalculatorController>(Lifetime.Singleton).AsImplementedInterfaces();
            
            builder.Register<CalculatorWindowViewModel>(Lifetime.Transient).AsImplementedInterfaces();
            builder.RegisterFactory<MessageWindowData, IMessageWindowViewModel>(_ =>
            {
                return data => new MessageWindowViewModel(data);
            }, Lifetime.Transient);
        }

        private static void RegisterWindowsService(IContainerBuilder builder)
        {
            builder.RegisterInstance(new WindowsManagerSettings("GUI/Canvas", "GUI/InputBlocker"));
            builder.Register<IWindowsManager, WindowsManager>(Lifetime.Transient);
            builder.Register<IViewModelFactory, ViewModelFactory>(Lifetime.Singleton);
            builder.Register<IWindowsService, WindowsService>(Lifetime.Singleton);
        }
    }
}