using Core.Common.Data;
using Core.Game.Common.Systems;
using DG_Pack.Camera;
using UnityEngine;

namespace Core.Game.Player {
    public class PlayerFactory {
        public PlayerFactory(
            GeneralConfig config,
            LevelContext context,
            RuntimeData data,
            HolyStuffFactory holyStuffFactory,
            ICameraService camera
        ) {
            _camera = camera;
            _holyStuffFactory = holyStuffFactory;
            Config = config;
            Context = context;
            Data = data;
        }

        private GeneralConfig Config { get; }
        private LevelContext Context { get; }
        private RuntimeData Data { get; }
        private readonly HolyStuffFactory _holyStuffFactory;
        private readonly ICameraService _camera;


        public void Create() {
            var sample = Object.Instantiate(Config.player.actor.prefab, Context.player.point);
            sample.name = $"{sample.tag}";

            _holyStuffFactory.Create(sample.transform);
            sample.GetComponentInChildren<Hearing.Hearing>().Init(Config, Data);
            sample.GetComponent<Movement>().Direction = new InputService();
            
            Data.Player = sample.transform;
            _camera.Target = sample.transform;
        }
    }
}