using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;

namespace Core.Game.Player {
    public class PlayerSpawnSystem : IEcsInitSystem, IEcsRunSystem {
        private readonly EcsCustomInject<PlayerActorFactory> _factory = default;


        public void Init(IEcsSystems systems) => _factory.Value.Create();
        public void Run(IEcsSystems systems) { }
    }
}