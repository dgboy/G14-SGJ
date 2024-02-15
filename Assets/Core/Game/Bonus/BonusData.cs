using System.Collections.Generic;
using UnityEngine;

namespace Core.Game.Bonus {
    [System.Serializable]
    public class BonusData {
        public GameObject prefab;
        public AudioClip spawnSound;
        public AudioClip activationSound;
        public float cooldown = 10f;
        public float timeStopDuration = 10f;
        public StatusData invincible;
        public int current = -1;
        public List<BonusInfo> items;
    }
}