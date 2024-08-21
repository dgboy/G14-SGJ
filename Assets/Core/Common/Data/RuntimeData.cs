using System;
using DG_Pack.Base.Reactive;
using UnityEngine;

namespace Core.Common.Data {
    public class RuntimeData {
        public RuntimeData(GeneralConfig config) {
            FearLevel = new ReactiveToNew<float>(config.player.fearLevel);
            HearingLevel = new ReactiveToNew<int>(config.player.hearing.level);
            LifeTime = new ReactiveToNew<TimeSpan>();
            VillagerCounter = new ReactiveToNew<int>(config.villagerCounter);
            SavedVillagers = new ReactiveToNew<int>();
        }

        public Transform Player { get; set; }
        public ReactiveToNew<float> FearLevel { get; }
        public ReactiveToNew<int> HearingLevel { get; }
        public ReactiveToNew<TimeSpan> LifeTime { get; }
        public ReactiveToNew<int> VillagerCounter { get; }
        public ReactiveToNew<int> SavedVillagers { get; }
    }
}