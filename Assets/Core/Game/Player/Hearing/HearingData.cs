using System;
using UnityEngine;

namespace Core.Game.Player.Hearing {
    [Serializable]
    public class HearingData {
        public int level;

        public AudioClip[] low;
        public AudioClip[] middle;
        public AudioClip[] high;
    }
}