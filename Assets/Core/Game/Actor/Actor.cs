using Core.Game.Common.Behaviors;
using UnityEngine;

namespace Core.Game.Actor {
    public class Actor : MonoBehaviour {
        public Entity entity;
        public Rigidbody2D body;
        public int ID => entity.id;
    }
}