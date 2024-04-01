using System.Collections.Generic;
using Core.Game.Actor.Enemy;
using Core.Game.Actor.Player;
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