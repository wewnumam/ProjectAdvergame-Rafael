using ProjectTA.Boot;
using Agate.MVC.Base;
using Agate.MVC.Core;
using System.Collections;
using UnityEngine.SceneManagement;
using ProjectTA.Message;
using UnityEngine;
using ProjectTA.Utility;
using ProjectAdvergame.Module.GameplayState;

namespace ProjectTA.Scene.Level2
{
    public class Level2Launcher : SceneLauncher<Level2Launcher, Level2View>
    {
        public override string SceneName {get {return TagManager.SCENE_LEVEL2;}}

        private GameplayStateController _gameplayStateController;

        protected override IController[] GetSceneDependencies()
        {
            return new IController[] {
                new GameplayStateController(),
            };
        }

        protected override IConnector[] GetSceneConnectors()
        {
            return new IConnector[] {
                new GameplayStateConnector(),
            };
        }

        protected override IEnumerator LaunchScene()
        {
            yield return null;
        }

        protected override IEnumerator InitSceneObject()
        {
            Time.timeScale = 1;

            Publish(new GameStateMessage(EnumManager.GameState.PreGame));

            SceneManager.SetActiveScene(SceneManager.GetSceneByName(SceneName));

            _view.SetCallback(GoToMainMenu);

            _gameplayStateController.SetView(_view.GameplayStateView);

            yield return null;
        }

        private void GoToMainMenu()
        {
            SceneLoader.Instance.LoadScene(TagManager.SCENE_MAINMENU);
        }
    }
}
