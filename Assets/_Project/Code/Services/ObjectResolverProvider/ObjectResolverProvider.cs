#nullable enable
using JetBrains.Annotations;
using VContainer;

namespace Nuclear.Services
{
    [UsedImplicitly]
    public class ObjectResolverProvider : IObjectResolverProvider
    {
        private readonly IObjectResolver _container;

        public ObjectResolverProvider(IObjectResolver container)
        {
            _container = container;
        }

        IObjectResolver IObjectResolverProvider.Container => _container;
    }
}