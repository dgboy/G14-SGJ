using Core.Common.Data;
using Core.Game.Common.Behaviors;
using Core.Game.Map.Flammable;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;

namespace Core.Game.Map.Mine {
    public class MineSpawnSystem : IEcsInitSystem {
        // private readonly EcsCustomInject<LevelContext> _context = default;
        // private readonly EcsCustomInject<MineFactory> _factory = default;

        public void Init(IEcsSystems systems) {
            // foreach (var entity in _context.Value.mineContainer.GetComponentsInChildren<Entity>()) {
            //     _factory.Value.Create(entity);
            // }
        }
    }
}