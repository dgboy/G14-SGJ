using Core.Common.Data;
using Unity.VisualScripting;
using UnityEngine;
using VContainer;
using Cooldown = Core.Game.Common.Cooldown;

namespace Core.Game.Enemy.Banshee {
    public class VillagerFactory : MonoBehaviour, IFactory {
        [Inject] private GeneralConfig Config { get; set; }
        [Inject] private RuntimeData Data { get; set; }

        private const int Range = 10;
        private Cooldown _cooldown;
        private static readonly Vector3 Bounds = new(5f, 5f, 0);
        private float CooldownTime { get; set; } = 20f;


        private void Start() {
            _cooldown = new Cooldown(this);
            _cooldown.Start(3f);
        }
        private void Update() {
            if (_cooldown.IsExpired && Data.VillagerCounter.Value > 0)
                Create();
        }

        public void Create() {
            var position = new Vector3(Random.Range(0, Range), Random.Range(0, Range));// - Bounds;
            var sample = Object.Instantiate(Config.villagerPrefab, position, Quaternion.identity).GetComponent<Villager>();
            sample.Initialize(Data);
            
            _cooldown.Start(CooldownTime);
            Data.VillagerCounter.Value--;
        }
    }
}