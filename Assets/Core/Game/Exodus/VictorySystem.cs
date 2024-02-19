using Core.Common.Data;
using DG.Tweening;
using VContainer;
using VContainer.Unity;

namespace Core.Game.Exodus {
    public class VictorySystem : ITickable {
        [Inject] private readonly ExodusService _exodus;
        [Inject] private readonly RuntimeData _data;

        private bool HasPossessedVillagers => _data.PossessedVillagers.Value > 0;
        private Sequence _seq;


        public void Tick() {
            if (_exodus.Has || HasPossessedVillagers)
                return;

            _exodus.Declare(ExodusID.Victory);
            // _seq = DOTween.Sequence();
            // _seq.PrependInterval(5f);
            // _seq.AppendCallback(() => _exodus.Declare(ExodusID.Victory));
        }
    }
}