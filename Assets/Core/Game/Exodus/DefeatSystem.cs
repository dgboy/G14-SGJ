using System;
using Core.Common.Data;
using VContainer;
using VContainer.Unity;

namespace Core.Game.Exodus {
    public class DefeatSystem : IInitializable, ITickable {
        [Inject] private readonly GeneralConfig _config;
        [Inject] private readonly RuntimeData _data;
        [Inject] private readonly ExodusService _exodus;

        private DateTime _exodusTime;

        public void Initialize() {
            _exodusTime = DateTime.Now.AddMinutes(_config.exodus.lifetime);
            _data.LifeTime.Value = _exodusTime - DateTime.Now;
        }
        public void Tick() {
            if (_exodus.Has)
                return;

            if (_data.LifeTime.Value <= TimeSpan.Zero || _data.FearLevel.Value <= 0) {
                _exodus.Declare(ExodusID.Defeat);
                return;
            }

            _data.LifeTime.Value = _exodusTime - DateTime.Now;
        }
    }
}