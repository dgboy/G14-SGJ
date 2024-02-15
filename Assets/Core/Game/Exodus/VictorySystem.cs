using Core.Common.Data;
using DG.Tweening;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;

namespace Core.Game.Exodus {
    public class VictorySystem : IEcsRunSystem {
        private readonly EcsCustomInject<ExodusService> _exodus = default;
        private readonly EcsCustomInject<RuntimeData> _data = default;
        private Sequence _seq;
        // private readonly EcsFilterInject<Inc<CEnemy>> _filter = default;
        private bool HasPossessedVillagers => _data.Value.PossessedVillagers.Value > 0;


        public void Run(IEcsSystems systems) {
            if (_exodus.Value.Has || HasPossessedVillagers)
                return;

            _exodus.Value.Declare(ExodusID.Victory);
            // _seq = DOTween.Sequence();
            // _seq.PrependInterval(5f);
            // _seq.AppendCallback(() => _exodus.Value.Declare(ExodusID.Victory));
        }
    }
}