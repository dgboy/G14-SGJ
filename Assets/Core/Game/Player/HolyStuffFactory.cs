using Core.Common.Data;
using Leopotam.EcsLite;
using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace Core.Game.Player {
    public class HolyStuffFactory {
        public HolyStuffFactory(EcsWorld world, GeneralConfig config) {
            // Factory = factory;
            Config = config;
            // Context = context;
            // Data = data;

            _world = world;
            _lights = world.GetPool<CHolyStuff>();
        }

        private GeneralConfig Config { get; }
        // private LevelContext Context { get; }
        // private RuntimeData Data { get; }
        // private CharacterFactory Factory { get; }
        private readonly EcsWorld _world;
        private readonly EcsPool<CHolyStuff> _lights;


        public void Create(Transform user) {
            var offset = new Vector3(-0.4f, 0.7f, 0);
            var sample = Object.Instantiate(Config.holyStuffPrefab, offset, Quaternion.identity, user);
            sample.name = $"Holy Stuff ({user.name})";

            int id = _world.NewEntity();

            ref var light = ref _lights.Add(id);
            light.value = sample.GetComponent<Light2D>();
            light.value.pointLightOuterRadius = 0.2f;
        }
    }
}