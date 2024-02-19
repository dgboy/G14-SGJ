using Core.Common.Data;
using DG_Pack.Camera;
using UnityEngine;

namespace Core.Game.Player {
    public class PlayerCharacterFactory {
        public PlayerCharacterFactory(
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
            var sample = Object.Instantiate(Config.player.tank.prefab, Context.player.point);
            sample.name = $"{sample.tag}";

            _holyStuffFactory.Create(sample.transform);
            sample.GetComponentInChildren<Hearing>().Init(Config, Data);
            
            Data.Player = sample.transform;
            _camera.Target = sample.transform;
        }
    }
}