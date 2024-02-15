using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;

namespace Core.Game.Bullet {
    public class GunfireSystem : IEcsRunSystem {
        private readonly EcsCustomInject<BulletFactory> _factory = default;
        private readonly EcsFilterInject<Inc<EHolyStuff, CBody, CMovement, CCooldown>, Exc<SRecharge>> _filter = default;
        private readonly EcsPoolInject<CMovement> _movements = default;
        private readonly EcsPoolInject<CBody> _bodies = default;
        private readonly EcsPoolInject<CCooldown> _cooldownPool = default;
        private readonly EcsPoolInject<SRecharge> _rechargePool = default;


        public void Run(IEcsSystems systems) {
            foreach (int id in _filter.Value) {
                var body = _bodies.Value.Get(id);
                var movement = _movements.Value.Get(id);
                _factory.Value.Create(body.value, movement.direction, body.value.tag);

                var cooldown = _cooldownPool.Value.Get(id);
                ref var recharge = ref _rechargePool.Value.Add(id);
                recharge.Expired = cooldown.value;
            }
        }
    }
}