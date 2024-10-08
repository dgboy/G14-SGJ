using System.Collections.Generic;
using Core.Common.Data;
using Core.Game.Exodus;
using Core.Home;
using DG_Pack.Services.FSM;
using DG_Pack.UI.Toolkit;
using DG_Pack.UI.Toolkit.Elements.Input;
using DG_Pack.UI.Toolkit.Elements.Style;
using DG_Pack.UI.Toolkit.Elements.Text;
using DG_Pack.UI.Toolkit.Elements.Transform;
using VContainer;

namespace Core.Game.UI {
    public class UIFactory {
        [Inject] private RuntimeData Data { get; set; }
        [Inject] private IStateMachine StateMachine { get; set; }
        [Inject] private ExodusService Exodus { get; set; }

        public Dictionary<ViewID, IView> Create() => new() {
            [ViewID.HUD] = new View(
                "top-bar",
                handlers: new List<IHandler> {
                    new VarText<int>("villagers-value", Data.SavedVillagers),
                    new TimeText("lifetime-value", Data.LifeTime),
                    new TransformScale("fear-icon", Data.FearLevel),
                    new SymbolBar("hearing-value", Data.HearingLevel, '>'),
                }
            ),
            [ViewID.DefeatModal] = new View(
                "defeat-modal",
                handlers: new List<IHandler> {
                    new Text("title", Exodus.Title),
                    new Text("last-message", Exodus.Message),
                    new FontColor("last-message", Exodus.MessageColor),
                    new Click("restart", StateMachine.Enter<HomeState>),
                }
            ),
        };
    }
}