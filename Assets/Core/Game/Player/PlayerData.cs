using Core.Game.Tank;

namespace Core.Game.Player {
    [System.Serializable]
    public class PlayerData {
        public TankData tank;
        public int liveCount;
        public float fearLevel;
        public int hearingLevel;
    }
}