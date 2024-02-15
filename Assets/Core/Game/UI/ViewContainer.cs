using System.Collections.Generic;
using Core.Common;
using Core.Common.UI;
using UnityEngine.UIElements;

namespace Core.Game.UI {
    public class ViewContainer {
        public ViewContainer(VisualElement target, List<IViewHandler> handlers = null) {
            _target = target;
            Handlers = handlers ?? new List<IViewHandler>();
        }

        private readonly VisualElement _target;
        private List<IViewHandler> Handlers { get; }

        public void Init() => Handlers.ForEach(x => x.Bind(_target));
        public void Clear() => Handlers.ForEach(x => x.Unbind());

        public void Show() {
            Handlers.ForEach(x => x.Refresh());
            _target.visible = true;
        }
        public void Hide() => _target.visible = false;
    }
}