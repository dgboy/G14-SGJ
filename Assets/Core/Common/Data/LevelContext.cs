using System.Collections.Generic;
using Core.Game.Enemy;
using Core.Game.Map.Flammable;
using Core.Game.Player;
using Core.Game.UI;
using UnityEngine;

namespace Core.Common.Data {
    public class LevelContext : MonoBehaviour {
        public UIHandler ui;
        public AudioSource musicSource;
        public PlayerContext player;
        public EnemyContext enemy;
        public List<RedBarrel> redBarrels;
    }
}