using System;
using Core.Game.Player.Hearing;
using Core.Game.Tank;
using UnityEngine;

namespace Core.Game.Player {
    [Serializable]
    public class PlayerData {
        public ActorData actor;
        public HearingData hearing;

        public int liveCount;
        public float fearLevel;
        public GameObject holyStuffPrefab;
    }
}