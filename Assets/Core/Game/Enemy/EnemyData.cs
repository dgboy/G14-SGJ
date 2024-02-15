using Core.Game.Enemy.Spawn;

namespace Core.Game.Enemy {
    [System.Serializable]
    public class EnemyData {
        public EnemySpawnData spawn;
        public EnemyUnitData[] units;
    }
}