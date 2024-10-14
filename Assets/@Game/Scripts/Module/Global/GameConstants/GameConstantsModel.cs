using Agate.MVC.Base;

namespace ProjectTA.Module.GameConstants
{
    public class GameConstantsModel : BaseModel, IGameConstantsModel
    {
        public SO_GameConstants GameConstants { get; private set; }

        public void SetGameConstants(SO_GameConstants gameConstants)
        {
            GameConstants = gameConstants;
            SetDataAsDirty();
        }
    }
}