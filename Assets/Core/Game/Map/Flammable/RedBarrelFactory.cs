using Core.Common.Data;
using Leopotam.EcsLite;

namespace Core.Game.Map.Flammable {
    public class RedBarrelFactory {
        public RedBarrelFactory(EcsWorld world, GeneralConfig config) {
            _config = config;
            _world = world;
            _flammables = world.GetPool<CFlammable>();
            _explosives = world.GetPool<CExplosive>();
            _transforms = world.GetPool<CTransform>();
        }

        private readonly GeneralConfig _config;
        private readonly EcsWorld _world;
        private readonly EcsPool<CFlammable> _flammables;
        private readonly EcsPool<CTransform> _transforms;
        private readonly EcsPool<CExplosive> _explosives;


        public void Create(RedBarrel sample) {
            int id = _world.NewEntity();
            sample.name = $"red barrel {id}";
            sample.entity.id = id;

            ref var flammable = ref _flammables.Add(id);
            flammable.position = sample.transform.position;
            flammable.radius = 1.28f;

            _explosives.Add(id);

            ref var transform = ref _transforms.Add(id);
            transform.value = sample.transform;
        }
    }
}