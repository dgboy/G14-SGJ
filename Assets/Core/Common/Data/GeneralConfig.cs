using Core.Game.Enemy.Banshee;
using Core.Game.Exodus;
using Core.Game.Player;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Core.Common.Data {
    [CreateAssetMenu(menuName = "Game/General", fileName = "General", order = 0)]
    public class GeneralConfig : ScriptableObject {
        public PlayerData player;
        public ExodusData exodus;

        public Banshee bansheePrefab;

        public int villagerCounter = 10;
        public Object villagerPrefab;
    }
}