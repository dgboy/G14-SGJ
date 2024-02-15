using Core.Common.Data;
using Core.Common.Utils;
using Core.Game.Bonus.TimeStop;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using UnityEngine;

namespace Core.Game.Enemy {
    public class EnemyMovementSystem : IEcsRunSystem {
        private readonly EcsCustomInject<RuntimeData> _data = default;
        private readonly EcsFilterInject<Inc<CEnemy, CAgent, CMovement>> _filter = default;
        private readonly EcsPoolInject<CAgent> _agents = default;
        private readonly EcsPoolInject<CMovement> _movements = default;
        private readonly EcsPoolInject<SStopped> _stoppedPool = default;
        private Transform Target => _data.Value.Player;


        public void Run(IEcsSystems systems) {
            if (Target == null) return;

            foreach (int id in _filter.Value) {
                var agent = _agents.Value.Get(id);
                var transform = agent.value.transform;

                var goal = _stoppedPool.Value.Has(id) ? transform.position : Target.position; // TEMP
                agent.value.SetDestination(goal);

                Vector2 direction = (goal - transform.position).normalized;
                if (direction == Vector2.zero)
                    continue;

                agent.value.transform.rotation = direction.ToRotation();
                // var lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
                // transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5);

                ref var movement = ref _movements.Value.Get(id);
                movement.direction = direction;
            }
        }
    }
}