using Agate.MVC.Base;
using ProjectTA.Message;

namespace ProjectAdvergame.Module.ActionPlayer
{
    public class ActionPlayerConnector : BaseConnector
    {
        private ActionPlayerController _actionPlayer;

        protected override void Connect()
        {
            Subscribe<GameStartMessage>(_actionPlayer.OnGameStart);
        }

        protected override void Disconnect()
        {
            Unsubscribe<GameStartMessage>(_actionPlayer.OnGameStart);
        }
    }
}