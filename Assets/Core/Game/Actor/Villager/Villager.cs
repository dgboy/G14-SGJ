using Core.Common.Data;
using Core.Game.Common;
using DG.Tweening;
using UnityEngine;

namespace Core.Game.Actor.Enemy.Banshee {
    public class Villager : MonoBehaviour, IBanishAble {
        public new SpriteRenderer renderer;
        public new AudioSource audio;
        public RandomWalkingBehavior walkingBehavior;
        private Sequence _currentAnimation;
        private RuntimeData _data;


        public void Initialize(RuntimeData data) => _data = data;

        public void Banish() {
            if (!walkingBehavior.enabled)
                return;
            
            renderer.DOColor(Color.white, 0.5f);
            // IsPossessed = false;
            // audio.Stop();
            audio.enabled = false;
            walkingBehavior.enabled = false;
            _data.PossessedVillagers.Value--;
        }
    }
}