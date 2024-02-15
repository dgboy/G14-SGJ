using Core.Boot;
using Core.Game;
using Core.Game.UI;
using Core.Home;
using DG_Pack.Services.FSM;
using DG_Pack.Services.Log;
using DG_Pack.Services.Scene;
using VContainer;
using VContainer.Unity;

namespace Core.Base {
    public class RootScope : LifetimeScope {
        protected override void Configure(IContainerBuilder builder) {
            builder.Register<DyedLogger>(Lifetime.Singleton).As<ICustomLogger>();
            builder.Register<SceneService>(Lifetime.Singleton).As<ISceneService>();
            
            builder.Register<StateFactory>(Lifetime.Singleton).As<IStateFactory>();
            builder.Register<StateMachine>(Lifetime.Singleton).As<IStateMachine>();
            
            builder.Register<UIFactory>(Lifetime.Scoped);
            
            builder.Register<BootState>(Lifetime.Scoped);
            builder.Register<HomeState>(Lifetime.Scoped);
            builder.Register<GameState>(Lifetime.Scoped);
        }
    }
}