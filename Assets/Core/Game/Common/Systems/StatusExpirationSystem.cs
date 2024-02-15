using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using UnityEngine;

namespace Core.Game.Common.Systems {
    public class StatusExpirationSystem<TStatus> : IEcsRunSystem where TStatus : struct, IStatus {
        private readonly EcsFilterInject<Inc<TStatus>> _filter = default;
        private readonly EcsPoolInject<TStatus> _statuses = default;


        public void Run(IEcsSystems systems) {
            foreach (int id in _filter.Value) {
                ref var status = ref _statuses.Value.Get(id);
                status.Expired -= Time.deltaTime;

                if (status.Expired > 0)
                    continue;

                _statuses.Value.Del(id);
                // Debug.Log($"--- The <{status}> status for {id} is over! ---");
            }
        }
    }
}