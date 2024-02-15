using System;
using UnityEngine;

namespace Core.Common.Data {
    public class RuntimeData {
        public Transform Player { get; set; }
        
        public Observable<float> FearLevel { get; } = new(1f);
        public Observable<int> HearingLevel { get; } = new();
        public Observable<TimeSpan> LifeTime { get; } = new();
        public Observable<int> VillagerCounter { get; } = new();
        public Observable<int> PossessedVillagers { get; } = new();
    }
}