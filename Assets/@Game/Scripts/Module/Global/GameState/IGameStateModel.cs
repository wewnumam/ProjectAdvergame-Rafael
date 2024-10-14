using Agate.MVC.Base;
using ProjectTA.Utility;

namespace ProjectTA.Module.GameState
{
    public interface IGameStateModel : IBaseModel
    {
        EnumManager.GameState GameState { get; }
    }
}