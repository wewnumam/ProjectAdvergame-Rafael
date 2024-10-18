using Agate.MVC.Base;
using ProjectTA.Message;
using System;

namespace ProjectAdvergame.Module.GameplayState
{
    public class GameplayStateController : ObjectController<GameplayStateController, GameplayStateView>
    {
        public override void SetView(GameplayStateView view)
        {
            base.SetView(view);
            view.SetCallback(OnReady, OnFinish);
        }

        private void OnReady()
        {
            Publish(new GameStateMessage(ProjectTA.Utility.EnumManager.GameState.Playing));
            Publish(new GameStartMessage());
            _view.onPlay?.Invoke();
        }

        private void OnFinish()
        {
            Publish(new GameStateMessage(ProjectTA.Utility.EnumManager.GameState.GameWin));
            Publish(new GameWinMessage());
            _view.onPlay?.Invoke();
        }
    }
}