using Core.Game.Common.Behaviors;
using UnityEngine;

namespace Core.Game.Hit {
    [System.Serializable]
    public class HitData {
        public VisualFX vfx;
        public VisualFX deathVfx;
        public AudioClip deathSound;
        public AudioClip armorSound;
    }
}