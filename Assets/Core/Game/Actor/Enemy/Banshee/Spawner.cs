using Core.Common.Data;
using Core.Game.Common;
using UnityEngine;
using VContainer;

namespace Core.Game.Actor.Enemy.Banshee {
    public class Spawner : MonoBehaviour {
        [Inject] private GeneralConfig Config { get; set; }
        [Inject] private RuntimeData Data { get; set; }

        private const int Range = 10;
        private Cooldown _cooldown;
        private static readonly Vector3 Bounds = new(5f, 5f, 0);
        private float CooldownTime { get; set; } = 10f;
        public IFactory Factory { get; set; }


        private void Start() {
            _cooldown = new Cooldown(this);
            _cooldown.Start(3f);
        }
        private void Update() {
            if (!_cooldown.IsExpired || Data.VillagerCounter.Value <= 0)
                return;

            Factory.Create();
            _cooldown.Start(CooldownTime);
        }
    }
}