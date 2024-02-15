using Core.Common.Data;
using Core.Game.Common.Factories;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;

namespace Core.Game.Hit {
    public class HitEffectSystem : IEcsRunSystem {
        private readonly EcsCustomInject<GeneralConfig> _config = default;
        private readonly EcsCustomInject<VfxFactory> _vfxFactory = default;

        private readonly EcsWorldInject _world;
        private readonly EcsFilterInject<Inc<EHit, CTransform>> _filter = default;
        private readonly EcsPoolInject<EHit> _hits = default;


        public void Run(IEcsSystems systems) {
            foreach (int id in _filter.Value)
                _vfxFactory.Value.Create(_config.Value.hit.vfx, _hits.Value.Get(id).position);
        }
    }
}