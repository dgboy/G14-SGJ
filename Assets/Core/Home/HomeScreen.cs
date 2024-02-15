using Core.Game;
using DG_Pack.Services.FSM;
using UnityEngine;
using VContainer;

namespace Core.Home {
    public class HomeScreen : MonoBehaviour {
        [Inject] private IStateMachine State { get; set; }


        public void Play() => State.Enter<GameState>();
        public void Exit() => Application.Quit();
    }
}