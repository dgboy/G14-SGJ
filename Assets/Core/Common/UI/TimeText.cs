using System;
using UnityEngine.UIElements;

namespace Core.Common.UI {
    public class TimeText : IViewHandler {
        public TimeText(string name, Observable<TimeSpan> time) {
            _time = time;
            _name = name;
        }

        private readonly string _name;
        private readonly Observable<TimeSpan> _time;
        private TextElement _target;


        public void Bind(VisualElement root) {
            _target = root.Q<TextElement>(_name);
            _time.OnChanged += Refresh;
        }
        public void Unbind() => _time.OnChanged -= Refresh;

        public void Refresh() => _target.text = $"{_time.Value:mm\\:ss}"; //.ToString("mm':'ss");
    }
}