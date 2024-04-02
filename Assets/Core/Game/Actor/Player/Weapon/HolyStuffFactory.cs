using Core.Common.Data;
using Core.Game.Common.Input;
using Core.Game.Common.Systems;
using Unity.VisualScripting;
using UnityEngine;
using VContainer;

namespace Core.Game.Actor.Player.Weapon {
    public class HolyStuffFactory {
        [Inject] private GeneralConfig Config { get; set; }
        [Inject] private IInputService Input { get; set; }



        public void Create(Transform user, Transform point) {
            var sample = Object.Instantiate(Config.player.holyStuffPrefab, point).GetComponent<HolyStuff>();
            sample.name = $"Holy Stuff ({user.name})";
            sample.light.pointLightOuterRadius = 0.2f;

            var directionalRotation = point.AddComponent<DirectionalRotation>();
            directionalRotation.Input = Input;
        }
    }
}