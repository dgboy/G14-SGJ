using Core.Common.Data;
using UnityEngine;

namespace Core.Game.Actor.Player.Weapon {
    public class HolyStuffFactory {
        public HolyStuffFactory(GeneralConfig config) {
            Config = config;
        }

        private GeneralConfig Config { get; }


        public void Create(Transform user, Vector3 point) {
            var sample = Object.Instantiate(Config.player.holyStuffPrefab, point, Quaternion.identity, user).GetComponent<HolyStuff>();
            sample.name = $"Holy Stuff ({user.name})";
            sample.light.pointLightOuterRadius = 0.2f;
        }
    }
}