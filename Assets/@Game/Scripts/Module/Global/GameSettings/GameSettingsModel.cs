using Agate.MVC.Base;
using ProjectTA.Utility;
using System;

namespace ProjectTA.Module.GameSettings
{
    public class GameSettingsModel : BaseModel, IGameSettingsModel
    {
        public float AudioVolume { get; private set; } = 20f;

        public bool IsVibrateOn {  get; private set; } = true;

        internal void SetVibrate(bool vibrate)
        {
            IsVibrateOn = vibrate;
            SetDataAsDirty();
        }

        internal void SetVolume(float volume)
        {
            AudioVolume = volume;
            SetDataAsDirty();
        }
    }
}