using Agate.MVC.Base;

namespace ProjectTA.Module.GameConstants
{
    public interface IGameConstantsModel : IBaseModel
    {
        SO_GameConstants GameConstants { get; }
    }
}