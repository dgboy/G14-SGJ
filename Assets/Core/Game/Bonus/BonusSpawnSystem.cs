using Core.Common.Data;
using Core.Common.Utils;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using UnityEngine;

namespace Core.Game.Bonus {
    public class BonusSpawnSystem : IEcsRunSystem {
        private readonly EcsCustomInject<BonusFactory> _factory = default;
        private readonly EcsCustomInject<GeneralConfig> _config = default;
        private float Expired { get; set; } = Time.time; // + 5f;
        private BonusData Config => _config.Value.bonus;


        public void Run(IEcsSystems systems) {
            if (Time.time <= Expired)
                return;

            var info = Config.current != -1 ? Config.items[Config.current] : Config.items.GetAny();
            _factory.Value.Create(info);
            Expired = Time.time + Config.cooldown;
        }
    }
}