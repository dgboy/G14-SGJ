using Core.Common.Utils;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using UnityEngine;

namespace Core.Game.Player {
    public class PlayerInputSystem : IEcsRunSystem {
        private readonly EcsFilterInject<Inc<CPlayer, CMovement>> _filter;
        private readonly EcsPoolInject<CMovement> _movements;
        // private readonly EcsPoolInject<EHolyStuff> _gunfireEvents = default;


        public void Run(IEcsSystems systems) {
            foreach (int id in _filter.Value) {
                ref var movement = ref _movements.Value.Get(id);
                movement.value = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

                if (movement.value != Vector2.zero)
                    movement.direction = movement.value.Sign();

                // if (Input.GetKeyDown(KeyCode.F))
                //     _gunfireEvents.Value.Add(id);
            }
        }
    }
}