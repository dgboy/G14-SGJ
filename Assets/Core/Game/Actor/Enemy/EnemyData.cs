using Core.Game.Actor.Enemy.Spawn;

namespace Core.Game.Actor.Enemy {
    [System.Serializable]
    public class EnemyData {
        public EnemySpawnData spawn;
        public EnemyUnitData[] units;
    }
}