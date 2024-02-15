using Core.Boot;
using DG_Pack.Services.FSM;
using DG_Pack.Services.Log;
using VContainer;
using VContainer.Unity;

namespace Core.Base {
    public class EntryPoint : IStartable {
        [Inject] private ICustomLogger Logger { get; set; }
        [Inject] private IStateMachine Machine { get; set; }


        public void Start() {
            Logger.Log("START", this, Dye.Red);
            Machine.Enter<BootState>();
        }
    }
}