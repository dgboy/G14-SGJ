using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using VContainer;

namespace Core.Game.UI {
    public class UIDocumentTree : MonoBehaviour {
        [Inject] private UIFactory Factory { get; set; }

        public UIDocument document;
        private VisualElement Root => document.rootVisualElement;
        private Dictionary<ViewID, ViewContainer> Views { get; set; }


        public void Awake() {
            Views = Factory.Create(Root);

            foreach (var view in Views.Values)
                view.Init();
        }
        private void OnDestroy() {
            foreach (var view in Views.Values)
                view.Clear();
        }

        public void Show(ViewID id) {
            foreach (var view in Views.Values)
                view.Hide();

            Views[id].Show();
        }
    }
}