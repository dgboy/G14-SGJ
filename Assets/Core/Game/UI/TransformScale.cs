using Core.Common;
using Core.Common.UI;
using UnityEngine;
using UnityEngine.UIElements;

namespace Core.Game.UI {
    public class TransformScale : ViewHandler {
        public TransformScale(string name, Observable<float> scale) {
            _name = name;
            _scale = scale;
        }

        private readonly string _name;
        private readonly Observable<float> _scale;


        public override void Bind(VisualElement root) {
            base.Bind(root.Q(_name));
            _scale.OnChanged += Refresh;
        }
        public override void Unbind() {
            _scale.OnChanged -= Refresh;
        }

        public override void Refresh() => target.transform.scale = _scale.Value * Vector3.one;
    }
}