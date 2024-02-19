using Core.Common.Data;
using Core.Game.Common;
using Core.Game.Exodus;
using Core.Game.Player;
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
            builder.Register<ExodusService>(Lifetime.Scoped).AsSelf().As<IInitializable>();

            builder.Register<HolyStuffFactory>(Lifetime.Singleton);
            builder.Register<PlayerCharacterFactory>(Lifetime.Singleton);
            builder.RegisterEntryPoint<DefeatSystem>();
            builder.RegisterEntryPoint<VictorySystem>();

            builder.RegisterComponentInHierarchy<LevelContext>();
            builder.RegisterComponentInHierarchy<UIHandler>();
            builder.RegisterComponentInHierarchy<SmoothCamera>().As<ICameraService>();

            builder.RegisterEntryPoint<GameStartup>();
        }
    }
}