using UnityEngine;

namespace Core.Game.Tank {
    public class CharacterFactory {
        public Actor Create(ActorData data, Transform spawner, Vector2 direction) {
            var sample = Object.Instantiate(data.prefab, spawner.position, Quaternion.identity);
            sample.name = $"{sample.tag}";
            return sample;
        }
    }
}