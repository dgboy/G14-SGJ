using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;

namespace Core.Game.Common.Systems {
    public class AgentSpeedSystem : IEcsRunSystem {
        private readonly EcsFilterInject<Inc<CAgent, CSpeed>> _filter = default;
        private readonly EcsPoolInject<CAgent> _agents;
        private readonly EcsPoolInject<CSpeed> _speeds;


        public void Run(IEcsSystems systems) {
            foreach (int id in _filter.Value) {
                ref var agent = ref _agents.Value.Get(id);
                ref var speed = ref _speeds.Value.Get(id);
                agent.value.speed = speed.value;
            }
        }
    }
}