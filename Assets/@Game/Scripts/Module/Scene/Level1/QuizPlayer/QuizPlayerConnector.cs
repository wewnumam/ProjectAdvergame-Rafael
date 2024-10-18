using Agate.MVC.Base;
using ProjectTA.Message;

namespace ProjectAdvergame.Module.QuizPlayer
{
    public class QuizPlayerConnector : BaseConnector
    {
        private QuizPlayerController _quizPlayer;

        protected override void Connect()
        {
            Subscribe<GameStartMessage>(_quizPlayer.GameStart);
        }

        protected override void Disconnect()
        {
            Unsubscribe<GameStartMessage>(_quizPlayer.GameStart);
        }
    }
}