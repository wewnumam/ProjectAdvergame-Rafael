using Agate.MVC.Base;
using UnityEngine.UI;
using UnityEngine.Events;
using ProjectAdvergame.Module.ActionPlayer;
using ProjectAdvergame.Module.GameplayState;

namespace ProjectTA.Scene.Level3
{
    public class Level3View : BaseSceneView
    {
        public GameplayStateView GameplayStateView;
        public ActionPlayerView ActionPlayerView;
        public Button mainMenuButton;

        public void SetCallback(UnityAction onMainMenu)
        {
            mainMenuButton.onClick.RemoveAllListeners();
            mainMenuButton.onClick.AddListener(onMainMenu);
        }
    }
}
