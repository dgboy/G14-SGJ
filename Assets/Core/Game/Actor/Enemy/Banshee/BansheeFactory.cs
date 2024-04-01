using Core.Common.Data;
using Core.Game.Common;
using UnityEngine;
using VContainer;

namespace Core.Game.Actor.Enemy.Banshee {
    public class BansheeFactory : MonoBehaviour {
        // public BansheesFactory(GeneralConfig config, RuntimeData data, MonoBehaviour runner) {
        //     Config = config;
        //     Data = data;
        //     _cooldown = new Cooldown(runner);
        // }
        [Inject] private GeneralConfig Config { get; set; }
        [Inject] private RuntimeData Data { get; set; }

        private const int Range = 10;
        private Cooldown _cooldown;
        // private static readonly Vector3 Bounds = new(5f, 5f, 0);


        private void Start() {
            _cooldown = new Cooldown(this);
            _cooldown.Start(5f - Data.HearingLevel.Value);
        }
        private void Update() {
            if (_cooldown.IsExpired)
                Create();
        }

        private void Create() {
            var position = new Vector3(Random.Range(0, Range), Random.Range(0, Range));// - Bounds;
            var sample = Object.Instantiate(Config.bansheePrefab, position, Quaternion.identity);
            sample.Initialize(Data);
            _cooldown.Start(10f);
        }
    }
}