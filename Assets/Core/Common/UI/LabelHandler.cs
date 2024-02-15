using UnityEngine.UIElements;

namespace Core.Common.UI {
    public class LabelHandler<T> : IViewHandler {
        public LabelHandler(string name, Observable<T> variable) {
            _variable = variable;
            _name = name;
        }

        private readonly string _name;
        private readonly Observable<T> _variable;
        private Label _label;


        public void Bind(VisualElement root) {
            _label = root.Q<Label>(_name);
            _variable.OnChanged += Refresh;
        }
        public void Unbind() => _variable.OnChanged -= Refresh;

        public void Refresh() => _label.text = $"{_variable.Value}";
    }
}