namespace ProjectTA.Utility
{
    public class EnumManager
    {
        public enum Direction
        {
            FromEast,
            FromWest,
            FromNorth,
            CloseUp
        }

        public enum GameState
        {
            PreGame,
            Playing,
            Pause,
            GameOver,
            GameWin,
            ShowPadlock
        }
    }
}