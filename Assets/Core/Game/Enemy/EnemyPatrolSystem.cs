using Core.Common.Data;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using UnityEngine;

namespace Core.Game.Enemy {
    public class EnemyPatrolSystem : IEcsRunSystem {
        private readonly EcsCustomInject<LevelContext> _context = default;
        private readonly EcsFilterInject<Inc<CGoal, CBody, CMovement>> _filter = default;
        private readonly EcsPoolInject<CGoal> _goals;
        private readonly EcsPoolInject<CBody> _bodies;
        private readonly EcsPoolInject<CMovement> _movements;

        private Transform[] Points => _context.Value.enemy.patrolArea;


        public void Run(IEcsSystems systems) {
            foreach (int id in _filter.Value) {
                ref var body = ref _bodies.Value.Get(id);
                ref var goal = ref _goals.Value.Get(id);
                var position = body.value.position;

                var heading = new Vector2(position.x - Points[goal.value].position.x, 0);
                float distance = heading.magnitude;

                if (heading.sqrMagnitude < 0.1f) {
                    goal.value = (goal.value + 1) % Points.Length;
                } else {
                    ref var movement = ref _movements.Value.Get(id);
                    movement.value = -heading / distance;
                }
            }
        }
    }
}