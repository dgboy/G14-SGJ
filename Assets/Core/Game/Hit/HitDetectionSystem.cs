using System.Collections.Generic;
using Core.Game.Bullet;
using Core.Game.Common.Behaviors;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using UnityEngine;

namespace Core.Game.Hit {
    public class HitDetectionSystem : IEcsRunSystem {
        private readonly EcsFilterInject<Inc<CBullet, CTrigger>> _filter = default;
        private readonly EcsPoolInject<CTrigger> _triggers = default;
        private readonly EcsPoolInject<EHit> _hits = default;

        public void Run(IEcsSystems systems) {
            foreach (int id in _filter.Value) {
                var trigger = _triggers.Value.Get(id);
                var targets = trigger.value.Targets;
                if (targets.Count == 0)
                    continue;

                MarkHits(targets, trigger.value.transform.position);
                Debug.Log($"[{trigger.value.name}] " + $"targets[{targets.Count}] = ({string.Join(", ", targets)})");
            }
        }

        private void MarkHits(IEnumerable<Entity> entities, Vector3 position) {
            foreach (var entity in entities) {
                if (_hits.Value.Has(entity.id))
                    continue;

                ref var hit = ref _hits.Value.Add(entity.id);
                hit.position = position;
                hit.damage = 1;
            }
        }
    }
}