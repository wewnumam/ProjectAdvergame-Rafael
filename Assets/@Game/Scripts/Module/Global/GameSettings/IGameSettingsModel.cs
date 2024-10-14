using Agate.MVC.Base;
using ProjectTA.Utility;

namespace ProjectTA.Module.GameSettings
{
    public interface IGameSettingsModel : IBaseModel
    {
        float AudioVolume { get; }
        bool IsVibrateOn { get; }
    }
}