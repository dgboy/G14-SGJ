using UnityEngine.UIElements;

namespace Core.Common.UI {
    public class TextHandler : IViewHandler {
        public TextHandler(string name, Observable<string> text) {
            _name = name;
            _text = text;
        }

        private readonly string _name;
        private readonly Observable<string> _text;
        private TextElement _target;


        public void Bind(VisualElement root) {
            _target = root.Q<TextElement>(_name);
            _text.OnChanged += Refresh;
        }
        public void Unbind() => _text.OnChanged -= Refresh;
        public void Refresh() => _target.text = _text.Value;
    }
}