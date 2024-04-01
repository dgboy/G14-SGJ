using System.Collections.Generic;
using UnityEngine;

namespace Core.Game.Actor.Enemy {
    [System.Serializable]
    public class EnemyContext {
        public int counter;
        public List<Transform> spawners;
        public Transform[] patrolArea;
    }
}