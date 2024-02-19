using Core.Common.Data;
using Leopotam.EcsLite;
using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace Core.Game.Player {
    public class HolyStuffFactory {
        public HolyStuffFactory(GeneralConfig config) {
            Config = config;
        }

        private GeneralConfig Config { get; }


        public void Create(Transform user) {
            var offset = new Vector3(-0.4f, 0.7f, 0);
            var sample = Object.Instantiate(Config.holyStuffPrefab, offset, Quaternion.identity, user).GetComponent<HolyStuff>();
            sample.name = $"Holy Stuff ({user.name})";
            sample.light.pointLightOuterRadius = 0.2f;
        }
    }
}