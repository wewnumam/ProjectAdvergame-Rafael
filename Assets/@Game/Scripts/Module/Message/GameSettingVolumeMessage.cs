using ProjectTA.Utility;

namespace ProjectTA.Message
{
    public struct GameSettingVolumeMessage
    {
        public float Volume { get; }

        public GameSettingVolumeMessage(float volume)
        {
            Volume = volume;
        }
    }
}