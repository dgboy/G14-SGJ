using System.Collections.Generic;
using DG_Pack.UI.Toolkit;
using UnityEngine.UIElements;

namespace Core.Game.UI {
    public class AssetView : VisualElement, IHandler {
        public AssetView(VisualTreeAsset asset, List<IHandler> handlers, IEnumerable<string> classes = null) : this(asset, classes) =>
            Handlers = handlers;
        public AssetView(VisualTreeAsset asset, IHandler handler, IEnumerable<string> classes = null) : this(asset, classes) =>
            Handlers = new List<IHandler> { handler };
        private AssetView(VisualTreeAsset asset, IEnumerable<string> classes) {
            asset.CloneTree(this);
            SendToBack();
            AddClasses(classes);
        }

        public VisualElement Target => this;
        private List<IHandler> Handlers { get; }


        public virtual void Bind(VisualElement parent) {
            parent.Add(Target);
            Handlers.ForEach(x => x.Bind(Target));
        }
        public virtual void Unbind() {
            Handlers.ForEach(x => x.Unbind());
            Target.RemoveFromHierarchy();
        }

        public void Refresh() => Handlers.ForEach(x => x.Refresh());


        private void AddClasses(IEnumerable<string> classes) {
            if (classes == null) return;

            foreach (string className in classes)
                AddToClassList(className);
        }
    }
}