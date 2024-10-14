using Agate.MVC.Base;
using UnityEngine.UI;
using UnityEngine.Events;

namespace ProjectTA.Scene.Level2
{
    public class Level2View : BaseSceneView
    {
        public Button mainMenuButton;

        public void SetCallback(UnityAction onMainMenu)
        {
            mainMenuButton.onClick.RemoveAllListeners();
            mainMenuButton.onClick.AddListener(onMainMenu);
        }
    }
}
