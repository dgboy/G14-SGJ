using Core.Common.Data;
using Core.Game.Bonus.TimeStop;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using UnityEngine;

namespace Core.Game.Enemy {
    public class EnemyTurretSystem : IEcsRunSystem {
        private readonly EcsCustomInject<RuntimeData> _data = default;
        private readonly EcsFilterInject<Inc<CEnemy, CBody>, Exc<SStopped>> _filter = default;
        private readonly EcsPoolInject<CBody> _bodies = default;
        private readonly EcsPoolInject<EHolyStuff> _gunfireEvents = default;
        private Transform Target => _data.Value.Player;


        public void Run(IEcsSystems systems) {
            foreach (int id in _filter.Value) {
                if (Target)
                    _gunfireEvents.Value.Add(id);
            }
        }

        private bool InRangeFor(int id) {
            // var distance = Vector2.Distance(enemy.position, _player.Value.Target.position);
            // var direction = player.position - position;
            // var direction = Vector2.down;

            // var hit = Physics2D.Raycast(position, direction, 5);
            // if (!hit || !hit.transform.CompareTag(TagID.Player.ToString())) return;

            ref var body = ref _bodies.Value.Get(id);
            var distance = body.value.transform.position - Target.position;
            return Mathf.Abs(distance.x) < 0.05;
        }
    }
}