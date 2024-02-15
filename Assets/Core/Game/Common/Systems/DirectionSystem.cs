using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;

namespace Core.Game.Common.Systems {
    public class DirectionSystem : IEcsRunSystem {
        private readonly EcsFilterInject<Inc<CSpriteRenderer, CMovement>> _filter;
        private readonly EcsPoolInject<CSpriteRenderer> _renderers;
        private readonly EcsPoolInject<CMovement> _movements;


        public void Run(IEcsSystems systems) {
            foreach (int id in _filter.Value) {
                ref var movement = ref _movements.Value.Get(id);
                ref var renderer = ref _renderers.Value.Get(id);

                renderer.value.flipX = movement.direction.x > 0;
            }
        }
    }
}