using Core.Game.Tank;

namespace Core.Game.Enemy {
    [System.Serializable]
    public class EnemyUnitData {
        public EnemyType type;
        public int score = 100;
        public ActorData tank;
    }
}