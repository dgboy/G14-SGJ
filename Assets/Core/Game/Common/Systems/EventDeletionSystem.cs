using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;

namespace Core.Game.Common.Systems {
    public class EventDeletionSystem<TEvent> : IEcsRunSystem where TEvent : struct, IEvent {
        private readonly EcsFilterInject<Inc<TEvent>> _filter = default;
        private readonly EcsPoolInject<TEvent> _hits = default;


        public void Run(IEcsSystems systems) {
            foreach (int id in _filter.Value)
                _hits.Value.Del(id);
        }
    }
}