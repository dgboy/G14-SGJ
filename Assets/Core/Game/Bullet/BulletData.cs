using UnityEngine;

namespace Core.Game.Bullet {
    [System.Serializable]
    public class BulletData {
        public GameObject prefab;
        public float speed = 3f;
        public float offset = 0.5f;
        public float lifespan = 1f;
        public AudioClip sound;
    }
}