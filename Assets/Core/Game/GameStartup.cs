using System;
using Core.Common.Data;
using Core.Game.Actor.Player;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Core.Game {
    public class GameStartup : IStartable, IFixedTickable, ITickable, IDisposable {
        [Inject] private IObjectResolver Resolver { get; set; }
        [Inject] private GeneralConfig Config { get; set; }
        [Inject] private LevelContext Context { get; set; }
        [Inject] private RuntimeData Data { get; set; }
        [Inject] private PlayerFactory PlayerFactory { get; set; }


        public void Start() {
            PlayerFactory.Create();
        }

        public void FixedTick() {
        }
        public void Tick() {
            if (Input.GetKeyDown(KeyCode.Escape))
                Application.Quit();
        }

        public void Dispose() {
        }
    }
}