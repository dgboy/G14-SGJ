using System.Collections.Generic;
using System.Linq;
using Core.Common.Data;
using Core.Game.Map;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using UnityEngine;

namespace Core.Game.Hit {
    public class HitBlockSoundSystem : IEcsInitSystem, IEcsRunSystem {
        private readonly EcsCustomInject<GeneralConfig> _config = default;

        private readonly EcsWorldInject _world;
        private readonly EcsFilterInject<Inc<EHit, CBlock>> _filter = default;
        private readonly EcsPoolInject<CBlock> _blocks = default;
        private readonly EcsPoolInject<ESound> _sounds = default;
        private Dictionary<BlockType, AudioClip> _audios;


        public void Init(IEcsSystems systems) =>
            _audios = _config.Value.map.blocks.ToDictionary(x => x.type, x => x.hitSound);

        public void Run(IEcsSystems systems) {
            foreach (int id in _filter.Value) {
                ref var block = ref _blocks.Value.Get(id);
                ref var sound = ref _sounds.Value.Add(id);
                sound.value = _audios[block.type];
            }
        }
    }
}