using Core.Common.Data;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;

namespace Core.Game.Map.Flammable {
    public class RedBarrelSpawnSystem : IEcsInitSystem {
        private readonly EcsCustomInject<LevelContext> _context = default;
        private readonly EcsCustomInject<RedBarrelFactory> _factory = default;

        public void Init(IEcsSystems systems) {
            foreach (var barrel in _context.Value.redBarrels) {
                _factory.Value.Create(barrel);
            }
        }
    }
}