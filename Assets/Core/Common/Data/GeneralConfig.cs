using Core.Game.Actor.Enemy.Banshee;
using Core.Game.Actor.Player;
using Core.Game.Exodus;
using UnityEngine;

namespace Core.Common.Data {
    [CreateAssetMenu(menuName = "Game/General", fileName = "General", order = 0)]
    public class GeneralConfig : ScriptableObject {
        public PlayerData player;
        public ExodusData exodus;

        public Banshee bansheePrefab;

        public int villagerCounter = 10;
        public GameObject villagerPrefab;
    }
}