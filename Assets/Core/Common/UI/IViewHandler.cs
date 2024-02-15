using UnityEngine.UIElements;

namespace Core.Common.UI {
    public interface IViewHandler {
        void Bind(VisualElement root);
        void Unbind();

        void Refresh();
    }
}