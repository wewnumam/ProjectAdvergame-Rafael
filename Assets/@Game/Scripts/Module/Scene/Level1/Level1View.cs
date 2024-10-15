using Agate.MVC.Base;
using UnityEngine.UI;
using UnityEngine.Events;
using ProjectAdvergame.Module.QuizPlayer;

namespace ProjectTA.Scene.Level1
{
    public class Level1View : BaseSceneView
    {
        public QuizPlayerView QuizPlayerView;
        public Button mainMenuButton;

        public void SetCallback(UnityAction onMainMenu)
        {
            mainMenuButton.onClick.RemoveAllListeners();
            mainMenuButton.onClick.AddListener(onMainMenu);
        }
    }
}
