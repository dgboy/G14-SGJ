using UnityEngine.UIElements;

namespace Core.Common.UI {
    public class SymbolText : IViewHandler {
        public SymbolText(string name, Observable<int> count, char symbol) {
            _symbol = symbol;
            _count = count;
            _name = name;
        }

        private readonly string _name;
        private readonly Observable<int> _count;
        private readonly char _symbol;
        private TextElement _target;


        public void Bind(VisualElement root) {
            _target = root.Q<TextElement>(_name);
            _target.text = "";
            _count.OnChanged += Refresh;
        }
        public void Unbind() => _count.OnChanged -= Refresh;

        public void Refresh() {
            string text = "";
            for (int i = 0; i < _count.Value; i++) 
                text += _symbol;

            _target.text = text;
        }
    }
}