using Core.Game.Common.Behaviors;
using UnityEngine;

namespace Core.Game.Tank {
    public class Actor : MonoBehaviour {
        public Entity entity;
        public Rigidbody2D body;
        public int ID => entity.id;
    }
}