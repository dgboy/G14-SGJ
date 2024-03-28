using System.Collections.Generic;
using Core.Common;
using DG_Pack.UI.Toolkit;
using UnityEngine.UIElements;

namespace Core.Game.UI {
    public class View : Handler<VisualElement>, IView {
        public View(string name, List<IHandler> handlers = null) : base(name) {
            Handlers = handlers ?? new List<IHandler>();
        }

        private List<IHandler> Handlers { get; }

        public override void Bind(VisualElement parent) {
            base.Bind(parent);
            Handlers.ForEach(x => x.Bind(Target));
        }
        public override void Unbind() => Handlers.ForEach(x => x.Unbind());
        public override void Refresh() => Handlers.ForEach(x => x.Refresh());

        public void Show() {
            Refresh();
            Target.visible = true;
        }
        public void Hide() {
            Target.visible = false;
        }
    }
}