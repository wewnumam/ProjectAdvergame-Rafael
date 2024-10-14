using Agate.MVC.Base;
using System.Collections;
using UnityEngine;

namespace ProjectTA.Module.GameConstants
{
    public class GameConstantsController : DataController<GameConstantsController, GameConstantsModel, IGameConstantsModel>
    {
        public override IEnumerator Initialize()
        {
            SO_GameConstants gameConstants = Resources.Load<SO_GameConstants>(@"GameConstants");
            _model.SetGameConstants(gameConstants);

            return base.Initialize();
        }
    }
}
