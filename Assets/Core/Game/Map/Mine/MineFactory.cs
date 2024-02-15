using Core.Game.Common.Behaviors;
using Leopotam.EcsLite;

namespace Core.Game.Map.Mine {
    public class MineFactory {
        public MineFactory(EcsWorld world) {
            _world = world;
            _mines = world.GetPool<CMine>();
            _explosives = world.GetPool<CExplosive>();
            _transforms = world.GetPool<CTransform>();
            _triggers = world.GetPool<CTrigger>();
        }

        private readonly EcsWorld _world;
        private readonly EcsPool<CMine> _mines;
        private readonly EcsPool<CTransform> _transforms;
        private readonly EcsPool<CExplosive> _explosives;
        private readonly EcsPool<CTrigger> _triggers;


        public void Create(Entity sample) {
            int id = _world.NewEntity();
            sample.name = $"mine {id}";
            sample.id = id;

            _mines.Add(id);
            _explosives.Add(id);

            ref var transform = ref _transforms.Add(id);
            transform.value = sample.transform;
            
            ref var trigger = ref _triggers.Add(id);
            trigger.value = sample.GetComponent<EnterTrigger>();
        }
    }
}