using Core.Game.Player;
using Core.Game.Tank;
using Leopotam.EcsLite;
using UnityEngine;
using UnityEngine.AI;

namespace Core.Game.Enemy {
    public class EnemyTankFactory {
        public EnemyTankFactory(EcsWorld world, CharacterFactory characterFactory) {
            _characterFactory = characterFactory;
            _enemies = world.GetPool<CEnemy>();
            _goals = world.GetPool<CGoal>();
            _agents = world.GetPool<CAgent>();
            _scores = world.GetPool<CScore>();
            _world = world;
        }

        private readonly CharacterFactory _characterFactory;
        private readonly EcsWorld _world;
        private readonly EcsPool<CEnemy> _enemies;
        private readonly EcsPool<CGoal> _goals;
        private readonly EcsPool<CAgent> _agents;
        private readonly EcsPool<CScore> _scores;

        public void Create(EnemyUnitData data, Transform spawner) {
            int id = _world.NewEntity();
            _enemies.Add(id);

            var direction = Vector2.down;
            var sample = _characterFactory.Create(id, data.tank, spawner, direction);
            sample.name += $" ({data.type})";

            ref var agent = ref _agents.Add(id);
            agent.value = sample.GetComponent<NavMeshAgent>();

            ref var score = ref _scores.Add(id);
            score.value = data.score;

            _goals.Add(id);
        }
    }
}