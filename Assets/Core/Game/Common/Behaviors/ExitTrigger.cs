using Leopotam.EcsLite;
using UnityEngine;

namespace Core.Game.Common.Behaviors {
    [RequireComponent(typeof(Entity))]
    public class ExitTrigger : MonoBehaviour {
        public string target = "Untagged";
        public EcsWorld World { get; set; }


        private void OnTriggerEnter2D(Collider2D other) {
            // Debug.Log($"target: {other.name} [@{other.tag}]");
            MarkDie(GetComponent<Entity>());

            if (other.CompareTag(target)) return;
            if (!other.TryGetComponent<Entity>(out var entity)) return;

            MarkHit(entity.id);
        }


        private void MarkHit(int id) {
            var hits = World.GetPool<EHit>();
            ref var hit = ref hits.Add(id);
            hit.damage = 1;
            hit.position = transform.position;
        }
        private void MarkDie(Entity entity) {
            var deaths = World.GetPool<EDeath>();
            if (!deaths.Has(entity.id))
                deaths.Add(entity.id);
        }
    }
}