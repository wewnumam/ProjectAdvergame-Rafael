using Agate.MVC.Base;
using ProjectTA.Utility;

namespace ProjectTA.Module.GameState
{
    public class GameStateModel : BaseModel, IGameStateModel
    {
        public EnumManager.GameState GameState { get; private set; }

        public void SetGameState(EnumManager.GameState gameState)
        {
            GameState = gameState;
            SetDataAsDirty();
        }
    }
}