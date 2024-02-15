using Core.Common.Data;
using Core.Game.Bonus.Extra;
using Core.Game.Bonus.Grenade;
using Core.Game.Bonus.Invincibility;
using Core.Game.Bonus.Swap;
using Core.Game.Bonus.TimeStop;
using Core.Game.Common.Behaviors;
using Leopotam.EcsLite;
using UnityEngine;

namespace Core.Game.Bonus {
    public class BonusFactory {
        public BonusFactory(GeneralConfig config, EcsWorld world) {
            _config = config;
            _world = world;
            _bonuses = world.GetPool<CBonus>();
            _transforms = world.GetPool<CTransform>();
            _triggers = world.GetPool<CTrigger>();
            _lifespans = world.GetPool<CLifespan>();
            _soundEvents = world.GetPool<ESound>();
        }

        private readonly GeneralConfig _config;
        private readonly EcsWorld _world;
        private readonly EcsPool<CBonus> _bonuses;
        private readonly EcsPool<CTransform> _transforms;
        private readonly EcsPool<CLifespan> _lifespans;
        private readonly EcsPool<CTrigger> _triggers;
        private readonly EcsPool<ESound> _soundEvents;
        private BonusData Config => _config.bonus;


        public void Create(BonusInfo info) {
            var position = new Vector2(Random.Range(-5, 6), Random.Range(-4, 5));
            int id = _world.NewEntity();
            _bonuses.Add(id);
            AddTag(id, info.type);

            var sample = Object.Instantiate(Config.prefab, position, Quaternion.identity);
            sample.name = $"bonus {id} <{info.type}>";

            var entity = sample.GetComponent<Entity>();
            entity.id = id;

            var renderer = sample.GetComponent<SpriteRenderer>();
            renderer.sprite = info.sprite;

            ref var transform = ref _transforms.Add(id);
            transform.value = sample.transform;

            ref var lifespan = ref _lifespans.Add(id);
            lifespan.duration = 5f;

            ref var trigger = ref _triggers.Add(id);
            trigger.value = sample.GetComponent<EnterTrigger>();

            ref var sound = ref _soundEvents.Add(id);
            sound.value = Config.spawnSound;
        }

        private void AddTag(int id, BonusType type) {
            switch (type) {
                case BonusType.Grenade:
                    _world.GetPool<CGrenade>().Add(id);
                    break;
                case BonusType.TimeStop:
                    _world.GetPool<ETimeStop>().Add(id);
                    break;
                case BonusType.Invincible:
                    _world.GetPool<CInvincibility>().Add(id);
                    break;
                case BonusType.ExtraArmor:
                    _world.GetPool<CExtraArmor>().Add(id);
                    break;
                case BonusType.ExtraSpeed:
                    _world.GetPool<CExtraSpeed>().Add(id);
                    break;
                case BonusType.ExtraPower:
                    _world.GetPool<CExtraPower>().Add(id);
                    break;
                case BonusType.Swap:
                    _world.GetPool<CSwap>().Add(id);
                    break;
                default:
                    // Debug.Log($"{target.tag} picked up a <{bonus.type}> bonus - but it's not implemented :_(");
                    break;
            }
        }
    }
}