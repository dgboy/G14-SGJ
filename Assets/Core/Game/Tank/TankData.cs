namespace Core.Game.Tank {
    [System.Serializable]
    public class TankData {
        public Actor prefab;
        public float speed = 1f;
        public int health = 1;
        public float cooldown = 2f;
    }
}