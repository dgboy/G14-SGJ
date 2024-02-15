using System.Collections.Generic;
using UnityEngine;

namespace Core.Game.Enemy {
    [System.Serializable]
    public class EnemyContext {
        public int counter;
        public List<Transform> spawners;
        public Transform[] patrolArea;
    }
}