using DG_Pack.Services.FSM;
using DG_Pack.Services.Log;
using DG_Pack.Services.Scene;
using VContainer;

namespace Core.Home {
    public class HomeState : IState {
        [Inject] private ICustomLogger Logger { get; set; }
        [Inject] private ISceneService Scene { get; set; }
        [Inject] private IStateMachine State { get; set; }


        public async void Enter() {
            await Scene.Load(SceneID.Home);
        }
        public void Exit() { }
    }
}