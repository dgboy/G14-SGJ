using System;
using Core.Common.Data;
using Core.Game.Bonus;
using Core.Game.Bonus.Extra;
using Core.Game.Bonus.Grenade;
using Core.Game.Bonus.Invincibility;
using Core.Game.Bonus.Swap;
using Core.Game.Bonus.TimeStop;
using Core.Game.Bullet;
using Core.Game.Common.Factories;
using Core.Game.Common.Systems;
using Core.Game.Enemy;
using Core.Game.Enemy.Spawn;
using Core.Game.Exodus;
using Core.Game.Hit;
using Core.Game.Map;
using Core.Game.Map.Flammable;
using Core.Game.Map.Mine;
using Core.Game.Player;
using Core.Game.Respawn;
using Core.Game.Tank;
using DG_Pack.Camera;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Core.Game {
    public class GameStartup : IStartable, IFixedTickable, ITickable, IDisposable {
        [Inject] private IObjectResolver Resolver { get; set; }
        [Inject] private GeneralConfig Config { get; set; }
        [Inject] private LevelContext Context { get; set; }
        [Inject] private RuntimeData Data { get; set; }

        private EcsWorld World { get; set; }
        private EcsSystems _systems;
        private EcsSystems _fixedUpdateSystems;


        public void Start() {
            World = new EcsWorld();
            _systems = new EcsSystems(World);
            _fixedUpdateSystems = new EcsSystems(World);

            var characterFactory = new CharacterFactory(World);
            var holyStuffFactory = new HolyStuffFactory(World, Config);

            _fixedUpdateSystems
                // .Add(new EnemyPatrolSystem())
                .Add(new MovementSystem())
                // .Add(new EnemyMovementSystem())
                .Inject(Config)
                .Inject(Context)
                .Inject(Data)
                .Init();

            _systems
                .Add(new PlayerSpawnSystem())
                // .Add(new EnemySpawnSystem())
                // .Add(new BonusSpawnSystem())
                // .Add(new BlockFactorySystem())
                // .Add(new RedBarrelSpawnSystem())
                // .Add(new MineSpawnSystem())
                // .Add(new TriggerActivationSystem())
                // .Add(new MineActivationSystem())
                // .Add(new BonusActivationSystem())
                // .Add(new ExtraHealthActivationSystem())
                // .Add(new ExtraSpeedActivationSystem())
                // .Add(new GrenadeActivationSystem())
                // .Add(new InvincibilityActivationSystem())
                // .Add(new SwapSystem())
                // .Add(new AgentSpeedSystem())
                // .Add(new StoppingEnemySystem())
                // .Add(new EventDeletionSystem<EActivation>())
                .Add(new PlayerInputSystem())
                // .Add(new DirectionSystem())
                // .Add(new EnemyTurretSystem())
                .Add(new HolyStuffSystem())
                .Add(new EventDeletionSystem<EHolyStuff>())
                .Add(new HitDetectionSystem())
                // .Add(new HitFlammableSystem())
                // .Add(new HitDamageSystem())
                // .Add(new HitEffectSystem())
                // .Add(new HitTankArmorSoundSystem())
                // .Add(new HitBlockSoundSystem())
                // .Add(new EventDeletionSystem<EHit>())
                // .Add(new ExplosionSoundSystem())
                // .Add(new ExplosionEffectSystem())
                .Add(new SoundEffectSystem())
                .Add(new LifespanSystem())
                // .Add(new RespawnSystem())
                .Add(new TriggerDisappearSystem())
                // .Add(new PlayerScoreSystem())
                // .Add(new DestroySystem())
                .Add(new DefeatSystem())
                .Add(new VictorySystem())
                .Add(new StatusExpirationSystem<SRecharge>())
                .Add(new StatusExpirationSystem<SStopped>())
                .Add(new StatusExpirationSystem<SInvincible>())
#if UNITY_EDITOR
                .Add(new Leopotam.EcsLite.UnityEditor.EcsWorldDebugSystem())
                .Add(new Leopotam.EcsLite.UnityEditor.EcsSystemsDebugSystem())
#endif
                .Inject(Config)
                .Inject(Context)
                .Inject(Data)
                .Inject(characterFactory)
                .Inject(Resolver.Resolve<ExodusService>())
                .Inject(new PlayerCharacterFactory(World, Config, Context, Data, characterFactory, holyStuffFactory, Resolver.Resolve<ICameraService>()))
                .Inject(new EnemyTankFactory(World, characterFactory))
                .Inject(new VfxFactory(World))
                .Inject(new SfxFactory(Config, World))
                .Inject(new BulletFactory(World, Config))
                .Inject(new BonusFactory(Config, World))
                .Inject(new StatusVFXFactory<SInvincible>(World))
                .Inject(new RedBarrelFactory(World, Config))
                .Inject(new MineFactory(World))
                .Init();
        }

        public void FixedTick() => _fixedUpdateSystems?.Run();
        public void Tick() {
            _systems?.Run();
            
            if (Input.GetKeyDown(KeyCode.Escape)) 
                Application.Quit();
        }

        public void Dispose() {
            _fixedUpdateSystems?.Destroy();
            _fixedUpdateSystems = null;
            _systems?.Destroy();
            _systems = null;
            World?.Destroy();
            World = null;
        }
    }
}