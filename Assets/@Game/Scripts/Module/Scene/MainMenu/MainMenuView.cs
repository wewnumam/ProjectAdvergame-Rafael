using Agate.MVC.Base;
using UnityEngine.UI;
using UnityEngine.Events;

namespace ProjectTA.Scene.MainMenu
{
    public class MainMenuView : BaseSceneView
    {
        public UnityAction<string> goToLevel;
        public Button quitButton;

        public void GoToLevel(string level)
        {
            goToLevel?.Invoke(level);
        }

        public void SetCallbacks(UnityAction<string> goToLevel, UnityAction onQuit)
        {
            this.goToLevel = goToLevel;

            quitButton.onClick.RemoveAllListeners();
            quitButton.onClick.AddListener(onQuit);
        }
    }
}
