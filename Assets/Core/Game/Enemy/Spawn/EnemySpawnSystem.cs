using System.Collections.Generic;
using System.Linq;
using Core.Common;
using Core.Common.Data;
using Core.Game.Common.Factories;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using UnityEngine;

namespace Core.Game.Enemy.Spawn {
    public class EnemySpawnSystem : IEcsInitSystem, IEcsRunSystem {
        private readonly EcsCustomInject<GeneralConfig> _config = default;
        private readonly EcsCustomInject<LevelContext> _context = default;
        private readonly EcsCustomInject<RuntimeData> _data = default;
        // private readonly EcsCustomInject<EnemyTankFactory> _enemyFactory = default;
        private readonly EcsCustomInject<VfxFactory> _vfxFactory = default;
        private readonly EcsFilterInject<Inc<CEnemy>> _filter = default;

        private EnemyData Config => _config.Value.enemy;
        private EnemyContext Context => _context.Value.enemy;
        private Observable<int> Counter => _data.Value.VillagerCounter;
        private float _expired;
        private Transform _spawner;
        private Dictionary<EnemyType, EnemyUnitData> _units;
        private EnemyType Current => (EnemyType)Random.Range(0, _units.Count);


        public void Init(IEcsSystems systems) {
            _units = _config.Value.enemy.units.ToDictionary(x => x.type, x => x);
            Counter.Value = Context.counter;
        }

        public void Run(IEcsSystems systems) {
            if (Counter.Value == 0 || _filter.Value.GetEntitiesCount() == Context.spawners.Count)
                return;

            if (_expired == 0f) {
                Prepare();
                return;
            }

            if (Time.time <= _expired)
                return;

            // _enemyFactory.Value.Create(_units[Current], _spawner);
            Counter.Value--;
            _expired = 0;
        }

        private void Prepare() {
            _spawner = Context.spawners[Random.Range(0, Context.spawners.Count)];
            var vfx = _vfxFactory.Value.Create(Config.spawn.vfx, _spawner.position);
            _expired = Time.time + vfx.Duration;
        }
    }
}