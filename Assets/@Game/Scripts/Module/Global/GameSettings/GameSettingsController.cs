using Agate.MVC.Base;
using ProjectTA.Message;
using ProjectTA.Utility;
using System;
using System.Collections;
using UnityEngine;

namespace ProjectTA.Module.GameSettings
{
    public class GameSettingsController : DataController<GameSettingsController, GameSettingsModel, IGameSettingsModel>
    {
        public override IEnumerator Initialize()
        {
            if (PlayerPrefs.HasKey(TagManager.KEY_VOLUME))
            {
                _model.SetVolume(PlayerPrefs.GetFloat(TagManager.KEY_VOLUME));
            }
            else
            {
                _model.SetVolume(1);
                PlayerPrefs.SetFloat(TagManager.KEY_VOLUME, _model.AudioVolume);
            }

            if (PlayerPrefs.HasKey(TagManager.KEY_VIBRATE))
            {
                _model.SetVibrate(Convert.ToBoolean(PlayerPrefs.GetInt(TagManager.KEY_VIBRATE)));
            }
            else
            {
                _model.SetVibrate(true);
                PlayerPrefs.SetInt(TagManager.KEY_VIBRATE, Convert.ToInt32(_model.IsVibrateOn));
            }

            yield return base.Initialize();
        }

        internal void OnVolume(GameSettingVolumeMessage message)
        {
            _model.SetVolume(message.Volume);
            PlayerPrefs.SetFloat(TagManager.KEY_VOLUME, _model.AudioVolume);
        }

        internal void OnVibrate(GameSettingVibrateMessage message)
        {
            _model.SetVibrate(message.Vibrate);
            PlayerPrefs.SetInt(TagManager.KEY_VIBRATE, Convert.ToInt32(_model.IsVibrateOn));
        }
    }
}
