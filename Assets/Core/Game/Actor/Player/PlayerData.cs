using System;
using Core.Game.Actor.Player.Hearing;
using UnityEngine;

namespace Core.Game.Actor.Player {
    [Serializable]
    public class PlayerData {
        public ActorData actor;
        public HearingData hearing;

        public int liveCount;
        public float fearLevel;
        public GameObject holyStuffPrefab;
    }
}