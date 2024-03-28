using DG_Pack.UI.Toolkit;

namespace Core.Game.UI {
    public interface IView : IHandler {
        void Show();
        void Hide();
    }
}