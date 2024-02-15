using System.Collections.Generic;
using Core.Common.Data;
using Core.Common.UI;
using Core.Game.Exodus;
using Core.Home;
using DG_Pack.Services.FSM;
using UnityEngine.UIElements;
using VContainer;

namespace Core.Game.UI {
    public class UIFactory {
        [Inject] private RuntimeData Data { get; set; }
        [Inject] private IStateMachine StateMachine { get; set; }
        [Inject] private ExodusService Exodus { get; set; }

        public Dictionary<ViewID, ViewContainer> Create(VisualElement root) => new() {
            [ViewID.HUD] = new ViewContainer(
                root.Q("top-bar"),
                handlers: new List<IViewHandler> {
                    new LabelHandler<int>("villagers-value", Data.PossessedVillagers),
                    new TimeText("lifetime-value", Data.LifeTime),
                    new TransformScale("fear-icon", Data.FearLevel),
                    new SymbolText("hearing-value", Data.HearingLevel, '>'),
                }
            ),
            [ViewID.DefeatModal] = new ViewContainer(
                root.Q("defeat-modal"),
                handlers: new List<IViewHandler> {
                    new TextHandler("title", Exodus.Title),
                    new TextHandler("last-message", Exodus.Message),
                    new FontColor("last-message", Exodus.MessageColor),
                    new ClickHandler("restart", StateMachine.Enter<HomeState>),
                }
            ),
        };
    }
}