using ProjectTA.Boot;
using Agate.MVC.Base;
using Agate.MVC.Core;
using System.Collections;
using UnityEngine.SceneManagement;
using ProjectTA.Message;
using UnityEngine;
using ProjectTA.Utility;
using ProjectAdvergame.Module.QuizPlayer;
using ProjectAdvergame.Module.GameplayState;

namespace ProjectTA.Scene.Level1
{
    public class Level1Launcher : SceneLauncher<Level1Launcher, Level1View>
    {
        public override string SceneName {get {return TagManager.SCENE_LEVEL1;}}

        public QuizPlayerController _quizPlayerController;
        public GameplayStateController _gameplayStateController;

        protected override IController[] GetSceneDependencies()
        {
            return new IController[] {
                new GameplayStateController(),
                new QuizPlayerController(),
            };
        }

        protected override IConnector[] GetSceneConnectors()
        {
            return new IConnector[] {
                new GameplayStateConnector(),
                new QuizPlayerConnector(),
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

            _quizPlayerController.SetView(_view.QuizPlayerView);

            yield return null;
        }

        private void GoToMainMenu()
        {
            SceneLoader.Instance.LoadScene(TagManager.SCENE_MAINMENU);
        }
    }
}
