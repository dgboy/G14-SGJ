using Core.Game.Bonus;
using Core.Game.Bullet;
using Core.Game.Common.Behaviors;
using Core.Game.Enemy;
using Core.Game.Enemy.Banshee;
using Core.Game.Exodus;
using Core.Game.Hit;
using Core.Game.Map;
using Core.Game.Player;
using UnityEngine;

namespace Core.Common.Data {
    [CreateAssetMenu(menuName = "Game/General", fileName = "General", order = 0)]
    public class GeneralConfig : ScriptableObject {
        public PlayerData player;
        public EnemyData enemy;
        public BulletData bullet;
        public HitData hit;
        public MapData map;
        public BonusData bonus;
        public ExodusData exodus;

        public SoundFX sfx;
        public GameObject holyStuffPrefab;

        public HearingData hearing;

        public Banshee bansheePrefab;

        public int villagerCounter = 10;
        public Object villagerPrefab;
    }
    
    [System.Serializable]
    public class HearingData {
        public AudioClip[] low;
        public AudioClip[] middle;
        public AudioClip[] high;
    }
}