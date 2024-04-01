using Core.Common.Data;
using Core.Game.Actor.Player;
using Core.Game.Common;
using Core.Game.Exodus;
using Core.Game.UI;
using DG_Pack.Camera;
using VContainer;
using VContainer.Unity;

namespace Core.Game {
    public class GameScope : LifetimeScope {
        public GeneralConfig config;


        protected override void Configure(IContainerBuilder builder) {
            builder.RegisterInstance(config);
            builder.Register<RuntimeData>(Lifetime.Scoped);

            builder.Register<MusicService>(Lifetime.Scoped);
            builder.RegisterComponentInHierarchy<SmoothCamera>().As<ICameraService>();

            builder.Register<HolyStuffFactory>(Lifetime.Singleton);
            builder.Register<PlayerFactory>(Lifetime.Singleton);

            builder.Register<ExodusService>(Lifetime.Scoped).AsSelf().As<IInitializable>();
            builder.RegisterEntryPoint<DefeatSystem>();
            builder.RegisterEntryPoint<VictorySystem>();

            builder.RegisterComponentInHierarchy<LevelContext>();
            builder.RegisterComponentInHierarchy<UIDocumentTree>();

            builder.RegisterEntryPoint<GameStartup>();
        }
    }
}