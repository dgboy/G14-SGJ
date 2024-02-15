using Core.Common.Data;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;

namespace Core.Game.Respawn {
    public class RespawnSystem : IEcsRunSystem {
        private readonly EcsCustomInject<LevelContext> _context = default;

        private readonly EcsFilterInject<Inc<EDeath, CLife, CTransform>> _filter = default;
        private readonly EcsPoolInject<CLife> _lives = default;
        private readonly EcsPoolInject<EDeath> _deaths = default;
        private readonly EcsPoolInject<CHealth> _healths = default;
        private readonly EcsPoolInject<CTransform> _transforms = default;


        public void Run(IEcsSystems systems) {
            foreach (int id in _filter.Value) {
                ref var life = ref _lives.Value.Get(id);

                if (--life.value < 0)
                    continue;

                _deaths.Value.Del(id);

                ref var transform = ref _transforms.Value.Get(id);
                transform.value.position = _context.Value.player.point.position;

                if (_healths.Value.Has(id)) {
                    ref var health = ref _healths.Value.Get(id);
                    health.value = 1;
                }
            }
        }
    }
}