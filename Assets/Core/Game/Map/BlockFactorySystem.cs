using Core.Common.Data;
using Core.Game.Common.Behaviors;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using UnityEngine;

namespace Core.Game.Map {
    public class BlockFactorySystem : IEcsInitSystem {
        private readonly EcsCustomInject<LevelContext> _context = default;
        private readonly EcsWorldInject _world;
        private readonly EcsPoolInject<CBlock> _blocks = default;
        private readonly EcsPoolInject<CTransform> _transforms = default;
        private readonly EcsPoolInject<CHealth> _healths = default;
        private readonly EcsPoolInject<CBase> _bases = default;
        private LevelContext Context => _context.Value;


        public void Init(IEcsSystems systems) {
            // CreateBlock(Context.steelContainer, BlockType.Steel);
            // CreateBase(Context.baseContainer.GetChild(0));
            //
            // foreach (Transform brick in Context.brickContainer) {
            //     int id = CreateBlock(brick, BlockType.Brick);
            //     ref var health = ref _healths.Value.Add(id);
            //     health.value = 1;
            // }
        }
        private void CreateBase(Transform block) {
            int id = CreateBlock(block, BlockType.Base);
            _bases.Value.Add(id);
            ref var health = ref _healths.Value.Add(id);
            health.value = 1;
        }
        private int CreateBlock(Transform block, BlockType type) {
            int id = _world.Value.NewEntity();

            block.name = $"{type} {id}";
            block.GetComponent<Entity>().id = id;

            ref var tag = ref _blocks.Value.Add(id);
            tag.type = type;

            ref var transform = ref _transforms.Value.Add(id);
            transform.value = block;
            return id;
        }
    }
}