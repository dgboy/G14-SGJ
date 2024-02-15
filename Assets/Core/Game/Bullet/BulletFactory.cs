using Core.Common.Data;
using Core.Common.Utils;
using Core.Game.Common.Behaviors;
using Leopotam.EcsLite;
using UnityEngine;

namespace Core.Game.Bullet {
    public class BulletFactory {
        public BulletFactory(EcsWorld world, GeneralConfig config) {
            _config = config;
            _world = world;
            _bullets = world.GetPool<CBullet>();
            _triggers = world.GetPool<CTrigger>();
            _bodies = world.GetPool<CBody>();
            _transforms = world.GetPool<CTransform>();
            _movements = world.GetPool<CMovement>();
            _lifespans = world.GetPool<CLifespan>();
            _soundEvents = world.GetPool<ESound>();
            _speeds = world.GetPool<CSpeed>();
        }

        private readonly GeneralConfig _config;
        private readonly EcsWorld _world;
        private readonly EcsPool<CTrigger> _triggers;
        private readonly EcsPool<CBody> _bodies;
        private readonly EcsPool<CMovement> _movements;
        private readonly EcsPool<CTransform> _transforms;
        private readonly EcsPool<CLifespan> _lifespans;
        private readonly EcsPool<ESound> _soundEvents;
        private readonly EcsPool<CBullet> _bullets;
        private readonly EcsPool<CSpeed> _speeds;
        private BulletData Config => _config.bullet;


        public void Create(Rigidbody2D position, Vector2 direction, string tag) {
            Vector3 offset = position.position + direction * Config.offset;
            var sample = Object.Instantiate(Config.prefab, offset, direction.ToRotation());

            int id = _world.NewEntity();
            sample.name = $"Bullet {id} <{tag}>";
            sample.GetComponent<Entity>().id = id;

            _bullets.Add(id);

            ref var trigger = ref _triggers.Add(id);
            trigger.value = sample.GetComponent<EnterTrigger>();
            trigger.value.tag = tag;

            ref var transform = ref _transforms.Add(id);
            transform.value = sample.transform;

            ref var body = ref _bodies.Add(id);
            body.value = sample.GetComponent<Rigidbody2D>();

            ref var movement = ref _movements.Add(id);
            movement.direction = direction;
            movement.value = direction;
            
            ref var speed = ref _speeds.Add(id);
            speed.value = Config.speed;

            ref var lifespan = ref _lifespans.Add(id);
            lifespan.duration = Config.lifespan;

            ref var sound = ref _soundEvents.Add(id);
            sound.value = Config.sound;
            // Debug.Log($"[{sample.name}] vel: {movement.value}, offset: {direction * Config.offset}");
        }
    }
}