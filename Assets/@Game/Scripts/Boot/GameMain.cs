using Agate.MVC.Base;
using Agate.MVC.Core;
using ProjectTA.Module.GameConstants;
using ProjectTA.Module.GameSettings;
using ProjectTA.Module.GameState;
using System.Collections;
using UnityEngine;

namespace ProjectTA.Boot
{
    public class GameMain : BaseMain<GameMain>, IMain
    {
        protected override IConnector[] GetConnectors()
        {
            return new IConnector[] {
                new GameStateConnector(),
                new GameSettingsConnector(),
            };
        }

        protected override IController[] GetDependencies()
        {
            return new IController[] {
                new GameConstantsController(),
                new GameStateController(),
                new GameSettingsController(),
            };
        }

        protected override IEnumerator StartInit()
        {
            Application.targetFrameRate = -1;
            yield return null;
        }

        public void RunCoroutine(IEnumerator coroutine)
        {
            StartCoroutine(coroutine);
        }
    }
}
