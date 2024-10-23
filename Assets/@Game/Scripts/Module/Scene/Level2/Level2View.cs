using Agate.MVC.Base;
using UnityEngine.UI;
using UnityEngine.Events;
using ProjectAdvergame.Module.GameplayState;

namespace ProjectTA.Scene.Level2
{
    public class Level2View : BaseSceneView
    {
        public GameplayStateView GameplayStateView;
        public Button mainMenuButton;

        public void GoToMainMenu()
        {
            mainMenuButton.onClick.Invoke();
        }

        public void SetCallback(UnityAction onMainMenu)
        {
            mainMenuButton.onClick.RemoveAllListeners();
            mainMenuButton.onClick.AddListener(onMainMenu);
        }
    }
}
