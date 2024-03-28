using System;
using Core.Game.Common.Behaviors;
using Core.Game.Enemy;
using Core.Game.Enemy.Banshee;
using Core.Game.Exodus;
using Core.Game.Map;
using Core.Game.Player;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Core.Common.Data {
    [CreateAssetMenu(menuName = "Game/General", fileName = "General", order = 0)]
    public class GeneralConfig : ScriptableObject {
        public PlayerData player;
        public EnemyData enemy;
        public MapData map;
        public ExodusData exodus;

        public SoundFX sfx;
        public GameObject holyStuffPrefab;

        public HearingData hearing;

        public Banshee bansheePrefab;

        public int villagerCounter = 10;
        public Object villagerPrefab;
    }
    
    [Serializable]
    public class HearingData {
        public AudioClip[] low;
        public AudioClip[] middle;
        public AudioClip[] high;
    }
}