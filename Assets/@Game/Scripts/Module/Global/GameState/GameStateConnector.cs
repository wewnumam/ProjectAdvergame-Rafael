using Agate.MVC.Base;
using ProjectTA.Message;

namespace ProjectTA.Module.GameState
{
    public class GameStateConnector : BaseConnector
    {
        private GameStateController _gameState;

        protected override void Connect()
        {
            Subscribe<GameStateMessage>(_gameState.SetGameState);
        }

        protected override void Disconnect()
        {
            Unsubscribe<GameStateMessage>(_gameState.SetGameState);
        }
    }
}