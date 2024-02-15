using Core.Home;
using DG_Pack.Services.FSM;
using DG_Pack.Services.Scene;
using VContainer;

namespace Core.Boot {
    public class BootState : IState {
        [Inject] private IStateMachine State { get; set; }
        [Inject] private ISceneService Scene { get; set; }


        public async void Enter() {
            await Scene.Load(SceneID.Boot);
            Initialize();
            State.Enter<HomeState>();
        }
        public void Exit() { }


        private void Initialize() { }
    }
}