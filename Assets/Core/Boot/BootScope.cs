using Core.Base;
using VContainer;
using VContainer.Unity;

namespace Core.Boot {
    public class BootScope : LifetimeScope {
        protected override void Configure(IContainerBuilder builder) {
            builder.RegisterEntryPoint<EntryPoint>();
        }
    }
}