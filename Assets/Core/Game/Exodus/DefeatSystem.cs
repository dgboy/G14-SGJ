using System;
using Core.Common.Data;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;

namespace Core.Game.Exodus {
    public class DefeatSystem : IEcsInitSystem, IEcsRunSystem {
        private readonly EcsCustomInject<GeneralConfig> _config = default;
        private readonly EcsCustomInject<RuntimeData> _data = default;
        private readonly EcsCustomInject<ExodusService> _exodus = default;
        // private readonly EcsFilterInject<Inc<CPlayer>> _playerFilter = default;
        // private readonly EcsFilterInject<Inc<CBase>> _baseFilter = default;

        private RuntimeData Data => _data.Value;
        private DateTime _exodusTime;

        public void Init(IEcsSystems systems) {
            _exodusTime = DateTime.Now.AddMinutes(_config.Value.exodus.lifetime);
            Data.LifeTime.Value = _exodusTime - DateTime.Now;
        }
        public void Run(IEcsSystems systems) {
            if (_exodus.Value.Has)
                return;

            if (Data.LifeTime.Value <= TimeSpan.Zero || Data.FearLevel.Value <= 0) {
                _exodus.Value.Declare(ExodusID.Defeat);
                return;
            }

            Data.LifeTime.Value = _exodusTime - DateTime.Now;
        }
    }
}