using Agate.MVC.Base;
using ProjectTA.Message;

namespace ProjectTA.Module.GameSettings
{
    public class GameSettingsConnector : BaseConnector
    {
        private GameSettingsController _gameSettings;

        protected override void Connect()
        {
            Subscribe<GameSettingVolumeMessage>(_gameSettings.OnVolume);
            Subscribe<GameSettingVibrateMessage>(_gameSettings.OnVibrate);
        }

        protected override void Disconnect()
        {
            Unsubscribe<GameSettingVolumeMessage>(_gameSettings.OnVolume);
            Unsubscribe<GameSettingVibrateMessage>(_gameSettings.OnVibrate);
        }
    }
}