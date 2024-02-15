using Core.Game.Bullet;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;

namespace Core.Game.Player {
    public class HolyStuffSystem : IEcsRunSystem {
        private readonly EcsFilterInject<Inc<EHolyStuff, CHolyStuff>, Exc<SRecharge>> _filter = default;
        private readonly EcsPoolInject<CHolyStuff> _holyStuffs = default;
        // private readonly EcsPoolInject<CBody> _bodies = default;
        private readonly EcsPoolInject<CCooldown> _cooldownPool = default;
        private readonly EcsPoolInject<SRecharge> _rechargePool = default;


        public void Run(IEcsSystems systems) {
            foreach (int id in _filter.Value) {
                ref var holyStuff = ref _holyStuffs.Value.Get(id);
                holyStuff.value.pointLightOuterRadius = 1f;

                // holyStuff.value.gameObject.SetActive(true);

                var cooldown = _cooldownPool.Value.Get(id);
                ref var recharge = ref _rechargePool.Value.Add(id);
                recharge.Expired = cooldown.value;
            }
        }
    }
}