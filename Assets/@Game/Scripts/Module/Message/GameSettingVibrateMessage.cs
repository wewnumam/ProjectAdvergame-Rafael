using ProjectTA.Utility;

namespace ProjectTA.Message
{
    public struct GameSettingVibrateMessage
    {
        public bool Vibrate { get; }

        public GameSettingVibrateMessage(bool vibrate)
        {
            Vibrate = vibrate;
        }
    }
}