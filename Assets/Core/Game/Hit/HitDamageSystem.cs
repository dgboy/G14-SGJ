using Core.Game.Bonus.Invincibility;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;

namespace Core.Game.Hit {
    public class HitDamageSystem : IEcsRunSystem {
        private readonly EcsFilterInject<Inc<EHit, CHealth>, Exc<SInvincible>> _filter = default;
        private readonly EcsPoolInject<EHit> _hits = default;
        private readonly EcsPoolInject<CHealth> _healths = default;
        private readonly EcsPoolInject<EDeath> _deaths = default;


        public void Run(IEcsSystems systems) {
            foreach (int id in _filter.Value) {
                ref var health = ref _healths.Value.Get(id);
                ref var hit = ref _hits.Value.Get(id);

                health.value -= hit.damage;

                if (health.value <= 0) 
                    _deaths.Value.Add(id);
            }
        }
    }
}