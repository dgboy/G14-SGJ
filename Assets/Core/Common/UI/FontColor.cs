using UnityEngine;
using UnityEngine.UIElements;

namespace Core.Common.UI {
    public class FontColor : IViewHandler {
        public FontColor(string name, Observable<Color> color) {
            _name = name;
            _color = color;
        }

        private VisualElement Target { get; set; }
        private readonly string _name;
        private readonly Observable<Color> _color;


        public void Bind(VisualElement target) {
            Target = target.Q(_name);
            _color.OnChanged += Refresh;
        }
        public void Unbind() => _color.OnChanged -= Refresh;

        public void Refresh() => Target.style.color = _color.Value;
    }
}