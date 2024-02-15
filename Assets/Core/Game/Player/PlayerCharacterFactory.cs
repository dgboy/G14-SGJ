using Core.Common.Data;
using Core.Game.Respawn;
using Core.Game.Tank;
using Leopotam.EcsLite;
using UnityEngine;

namespace Core.Game.Player {
    public class PlayerCharacterFactory {
        public PlayerCharacterFactory(
            EcsWorld world,
            GeneralConfig config,
            LevelContext context,
            RuntimeData data,
            CharacterFactory characterFactory,
            HolyStuffFactory holyStuffFactory
        ) {
            _holyStuffFactory = holyStuffFactory;
            CharacterFactory = characterFactory;
            Config = config;
            Context = context;
            Data = data;

            _world = world;
            _players = world.GetPool<CPlayer>();
            _lives = world.GetPool<CLife>();
        }

        private GeneralConfig Config { get; }
        private LevelContext Context { get; }
        private RuntimeData Data { get; }
        private CharacterFactory CharacterFactory { get; }
        private readonly EcsWorld _world;
        private readonly EcsPool<CPlayer> _players;
        private readonly EcsPool<CLife> _lives;
        private readonly HolyStuffFactory _holyStuffFactory;


        public void Create() {
            int id = _world.NewEntity();
            _players.Add(id);

            var sample = CharacterFactory.Create(id, Config.player.tank, Context.player.point, Vector2.up);
            Data.Player = sample.transform;

            ref var life = ref _lives.Add(id);
            life.value = Config.player.liveCount;

            _holyStuffFactory.Create(sample.transform);
            sample.GetComponentInChildren<Hearing>().Init(Config, Data);
        }
    }
}