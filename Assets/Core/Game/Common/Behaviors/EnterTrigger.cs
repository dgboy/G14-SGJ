using System.Collections.Generic;
using UnityEngine;

namespace Core.Game.Common.Behaviors {
    [RequireComponent(typeof(Collider2D))]
    public class EnterTrigger : MonoBehaviour {
        public List<Entity> Targets { get; } = new();


        private void OnTriggerEnter2D(Collider2D other) {
            if (other.CompareTag(tag)) return; //other.isTrigger || 

            var entity = other.GetComponent<Entity>();
            if (entity != null)
                Targets.Add(entity);
        }
    }
}