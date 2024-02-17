using System;
using UnityEngine;

namespace Core.Common.Data {
    public class RuntimeData {
        public RuntimeData(GeneralConfig config) {
            FearLevel = new Observable<float>(config.player.fearLevel);
            HearingLevel = new Observable<int>(config.player.hearingLevel);
            LifeTime = new Observable<TimeSpan>();
            VillagerCounter = new Observable<int>(config.villagerCounter);
            PossessedVillagers = new Observable<int>(config.villagerCounter);
        }

        public Transform Player { get; set; }
        public Observable<float> FearLevel { get; }
        public Observable<int> HearingLevel { get; }
        public Observable<TimeSpan> LifeTime { get; }
        public Observable<int> VillagerCounter { get; }
        public Observable<int> PossessedVillagers { get; }
    }
}