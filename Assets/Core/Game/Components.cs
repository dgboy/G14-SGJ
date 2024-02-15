using Core.Game.Common.Behaviors;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Rendering.Universal;

namespace Core.Game {
    public interface IEvent { }
    public interface IStatus { public float Expired { get; set; } }

    public struct CTank { public string group; }
    public struct CPlayer {  }
    public struct CEnemy {  }

    public struct EDeath : IEvent {  }
    public struct ESound : IEvent { public AudioClip value; }

    public struct CTransform { public Transform value; }
    public struct CBody { public Rigidbody2D value; }
    public struct CSpriteRenderer { public SpriteRenderer value; }
    public struct CTrigger { public EnterTrigger value; }
    public struct EActivation : IEvent { public Entity by; }
    public struct CAnimator { public Animator value; }
    public struct CAgent { public NavMeshAgent value; }
    public struct CGoal { public int value; }

    public struct CMovement {
        public Vector2 value;
        public Vector2 direction;
    }
    public struct CSpeed { public float value; }
    public struct CLifespan { public float duration; }
    public struct CExplosive { }

    // BATTLE
    public struct EHit : IEvent {
        public int damage;
        public Vector2 position;
    }
    public struct EHolyStuff : IEvent {  }
    public struct SRecharge : IStatus { public float Expired { get; set; } }
    public struct AWeapon {
        public CCooldown cooldown;
        public int damage;
    }
    public struct CCooldown { public float value; }
    public struct CDamage { public int value; }
    public struct CHealth { public int value; }
    public struct CHolyStuff { public Light2D value; }
}