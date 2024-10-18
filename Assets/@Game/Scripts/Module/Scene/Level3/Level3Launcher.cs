using ProjectTA.Boot;
using Agate.MVC.Base;
using Agate.MVC.Core;
using System.Collections;
using UnityEngine.SceneManagement;
using ProjectTA.Message;
using UnityEngine;
using ProjectTA.Utility;
using ProjectAdvergame.Module.ActionPlayer;
using ProjectAdvergame.Module.GameplayState;

namespace ProjectTA.Scene.Level3
{
    public class Level3Launcher : SceneLauncher<Level3Launcher, Level3View>
    {
        public override string SceneName {get {return TagManager.SCENE_LEVEL3;}}

        GameplayStateController _gameplayState;
        ActionPlayerController _actionPlayer;

        protected override IController[] GetSceneDependencies()
        {
            return new IController[] {
                new GameplayStateController(),
                new ActionPlayerController(),
            };
        }

        protected override IConnector[] GetSceneConnectors()
        {
            return new IConnector[] {
                new GameplayStateConnector(),
                new ActionPlayerConnector(),
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

            _gameplayState.SetView(_view.GameplayStateView);

            _actionPlayer.SetView(_view.ActionPlayerView);

            yield return null;
        }

        private void GoToMainMenu()
        {
            SceneLoader.Instance.LoadScene(TagManager.SCENE_MAINMENU);
        }
    }
}
