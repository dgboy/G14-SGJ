using UnityEngine.UIElements;

namespace Core.Common.UI {
    public abstract class ViewHandler : IViewHandler {
        protected VisualElement target;

        public virtual void Bind(VisualElement root) => target = root;
        public virtual void Unbind() { }
        public virtual void Refresh() { }
    }
}