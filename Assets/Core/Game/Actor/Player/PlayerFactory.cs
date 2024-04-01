using Core.Common.Data;
using Core.Game.Actor.Player.Hearing;
using Core.Game.Actor.Player.Weapon;
using Core.Game.Common.Systems;
using DG_Pack.Camera;
using UnityEngine;
using VContainer;

namespace Core.Game.Actor.Player {
    public class PlayerFactory {
        [Inject] private GeneralConfig Config { get; set; }
        [Inject] private LevelContext Context { get; set; }
        [Inject] private RuntimeData Data { get; set; }
        [Inject] private HolyStuffFactory StuffFactory { get; set; }
        [Inject] private ICameraService Camera { get; set; }


        public void Create() {
            var sample = (PlayerActor)Object.Instantiate(Config.player.actor.prefab, Context.player.point);
            sample.name = $"{sample.tag}";

            StuffFactory.Create(sample.transform, sample.lightSpot.transform.position);
            sample.GetComponentInChildren<Movement>().Direction = new InputService();
            sample.GetComponentInChildren<HearingSkill>().Init(Config, Data);

            Data.Player = sample.transform;
            Camera.Target = sample.transform;
        }
    }
}