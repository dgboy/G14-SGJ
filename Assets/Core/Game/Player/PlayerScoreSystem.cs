using Core.Common.Data;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;

namespace Core.Game.Player {
    public class PlayerScoreSystem : IEcsRunSystem {
        private readonly EcsFilterInject<Inc<EDeath, CScore>> _filter = default;
        private readonly EcsCustomInject<RuntimeData> _data = default;
        private readonly EcsPoolInject<CScore> _scores;


        public void Run(IEcsSystems systems) {
            foreach (int id in _filter.Value) {
                _data.Value.FearLevel.Value += _scores.Value.Get(id).value;
            }
        }
    }
}