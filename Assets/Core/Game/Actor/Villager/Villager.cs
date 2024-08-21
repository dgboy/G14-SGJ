using Core.Common.Data;
using Core.Game.Common;
using DG.Tweening;
using UnityEngine;

namespace Core.Game.Actor.Enemy.Banshee {
    public class Villager : MonoBehaviour, IBanishAble {
        public new SpriteRenderer renderer;
        public new AudioSource audio;
        public RandomWalkingBehavior walkingBehavior;
        public FollowingBehavior followingBehavior;
        private Sequence _currentAnimation;
        private RuntimeData _data;


        public void Initialize(RuntimeData data) {
            _data = data;
            followingBehavior.Target = _data.Player;
        }

        public void Banish() {
            if (!walkingBehavior.enabled)
                return;
            
            renderer.DOColor(Color.white, 0.5f);
            // IsPossessed = false;
            // audio.Stop();
            audio.enabled = false;
            _data.SavedVillagers.Value++;
            
            walkingBehavior.enabled = false;
            followingBehavior.enabled = true;
        }
    }
}