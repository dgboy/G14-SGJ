using System.Collections.Generic;
using Core.Game.Common.Behaviors;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using UnityEngine;

namespace Core.Game.Map.Flammable {
    public class HitFlammableSystem : IEcsRunSystem {
        private readonly EcsFilterInject<Inc<EHit, CFlammable>> _filter = default;
        private readonly EcsPoolInject<CFlammable> _flammables = default;
        private readonly EcsPoolInject<EHit> _hits = default;
        private readonly EcsPoolInject<EDeath> _deaths = default;
        private readonly List<Collider2D> _targets = new();
        private readonly ContactFilter2D _contactFilter = new ContactFilter2D().NoFilter();

        public void Run(IEcsSystems systems) {
            foreach (int id in _filter.Value) {
                ref var flammable = ref _flammables.Value.Get(id);
                _deaths.Value.Add(id);

                Physics2D.OverlapCircle(flammable.position, flammable.radius, _contactFilter, _targets);

                foreach (var target in _targets) {
                    var entity = target.GetComponent<Entity>();
                    if (entity == null || entity.id == id || target.isTrigger || _hits.Value.Has(entity.id))
                        continue;

                    ref var hit = ref _hits.Value.Add(entity.id);
                    hit.damage = 1;
                    hit.position = target.transform.position;
                }
            }
        }
    }
}