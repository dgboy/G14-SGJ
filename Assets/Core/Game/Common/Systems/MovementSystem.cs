using Core.Common.Utils;
using Core.Game.Bonus.TimeStop;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using UnityEngine;

namespace Core.Game.Common.Systems {
    public class MovementSystem : IEcsRunSystem {
        private readonly EcsFilterInject<Inc<CBody, CMovement, CSpeed>, Exc<SStopped, CEnemy>> _filter;
        private readonly EcsPoolInject<CBody> _bodies;
        private readonly EcsPoolInject<CMovement> _movements;
        private readonly EcsPoolInject<CSpeed> _speeds;


        public void Run(IEcsSystems systems) {
            foreach (int id in _filter.Value) {
                ref var body = ref _bodies.Value.Get(id);
                ref var movement = ref _movements.Value.Get(id);
                var speed = _speeds.Value.Get(id);

                body.value.velocity = movement.value.normalized * speed.value;
                if (movement.value != Vector2.zero) 
                    body.value.transform.eulerAngles = new Vector3(0, movement.value.x > 0 ? 180 : 0, 0);
                // body.value.transform.rotation = movement.direction.ToRotation();
            }
        }
    }
}