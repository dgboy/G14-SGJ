using DG_Pack.Services.FSM;
using VContainer;

namespace Core.Base {
    public class StateFactory : IStateFactory {
        [Inject] private IObjectResolver Container { get; set; }


        public TState Create<TState>() where TState : IExitAbleState =>
            Container.Resolve<TState>();
    }
}