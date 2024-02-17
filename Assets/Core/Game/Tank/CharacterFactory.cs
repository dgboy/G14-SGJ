using Leopotam.EcsLite;
using UnityEngine;

namespace Core.Game.Tank {
    public class CharacterFactory {
        public CharacterFactory(EcsWorld world) {
            _tanks = world.GetPool<CTank>();
            _explosives = world.GetPool<CExplosive>();
            _bodies = world.GetPool<CBody>();
            _transforms = world.GetPool<CTransform>();
            _movements = world.GetPool<CMovement>();
            _speeds = world.GetPool<CSpeed>();
            _healths = world.GetPool<CHealth>();
            _cooldowns = world.GetPool<CCooldown>();
            _renderers = world.GetPool<CSpriteRenderer>();
        }

        private readonly EcsPool<CTank> _tanks;
        private readonly EcsPool<CExplosive> _explosives;
        private readonly EcsPool<CTransform> _transforms;
        private readonly EcsPool<CBody> _bodies;
        private readonly EcsPool<CMovement> _movements;
        private readonly EcsPool<CHealth> _healths;
        private readonly EcsPool<CCooldown> _cooldowns;
        private readonly EcsPool<CSpeed> _speeds;
        private readonly EcsPool<CSpriteRenderer> _renderers;


        public TankBehavior Create(int id, TankData data, Transform spawner, Vector2 direction) {
            var sample = Object.Instantiate(data.prefab, spawner.position, Quaternion.identity);
            sample.entity.id = id;
            sample.name = $"{sample.tag} {id}";

            ref var tank = ref _tanks.Add(id);
            tank.group = sample.tag;

            _explosives.Add(id);

            ref var renderer = ref _renderers.Add(id);
            renderer.value = sample.GetComponent<SpriteRenderer>();

            ref var transform = ref _transforms.Add(id);
            transform.value = sample.transform;

            ref var body = ref _bodies.Add(id);
            body.value = sample.body;

            ref var movement = ref _movements.Add(id);
            movement.direction = direction;
            
            ref var speed = ref _speeds.Add(id);
            speed.value = data.speed;

            ref var health = ref _healths.Add(id);
            health.value = data.health;

            ref var cooldown = ref _cooldowns.Add(id);
            cooldown.value = data.cooldown;
            return sample;
        }
    }
}