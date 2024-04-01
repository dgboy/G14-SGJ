using System.Collections.Generic;
using Core.Game.Enemy;
using Core.Game.Player;
using Core.Game.UI;
using UnityEngine;

namespace Core.Common.Data {
    public class LevelContext : MonoBehaviour {
        public UIDocumentTree ui;
        public AudioSource musicSource;
        public PlayerContext player;
        public EnemyContext enemy;
    }
}