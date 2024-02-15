using Core.Game.Common.Factories;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using UnityEngine;

namespace Core.Game.Common.Systems {
    public class SoundEffectSystem : IEcsRunSystem {
        private readonly EcsCustomInject<SfxFactory> _sfxFactory = default;
        private readonly EcsWorldInject _world;
        private readonly EcsFilterInject<Inc<ESound>> _filter = default;
        private readonly EcsPoolInject<ESound> _sounds = default;


        public void Run(IEcsSystems systems) {
            foreach (int id in _filter.Value) {
                var sound = _sounds.Value.Get(id);

                if (sound.value == null) {
                    Debug.LogError($"NO SOUND! Can't play sfx for <{id}>");
                    continue;
                }

                _sfxFactory.Value.Create(sound.value);
                _sounds.Value.Del(id);
            }
        }
    }
}