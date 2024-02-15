using System;
using UnityEngine;
using UnityEngine.UIElements;

namespace Core.Common.UI {
    public class ClickHandler : IViewHandler {
        public ClickHandler(string name, Action action = null) {
            _action = action;
            _name = name;
        }

        private readonly string _name;
        private readonly Action _action;
        private VisualElement _target;


        public void Bind(VisualElement root) {
            _target = root.Q(_name);
            _target.RegisterCallback<ClickEvent>(Click);
        }
        public void Unbind() => _target.UnregisterCallback<ClickEvent>(Click);
        public void Refresh() { }

        private void Click(ClickEvent evt) {
            if (_action != null) _action();
            else Debug.Log($"[{GetType().Name}] clicking on <{_name}> - WIP");
        }
    }
}