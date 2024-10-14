using Agate.MVC.Base;
using Agate.MVC.Core;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace ProjectTA.Boot
{
    public class SplashScreen : BaseSplash<SplashScreen>
    {
        [SerializeField] GameObject _splashUI;
        [SerializeField] GameObject _transitionUI;
        [SerializeField] TMP_Text versionText;

        protected override IMain GetMain()
        {
            return GameMain.Instance;
        }

        protected override ILoad GetLoader()
        {
            return SceneLoader.Instance;
        }

        protected override void StartSplash()
        {
            base.StartSplash();
            versionText.SetText($"v{Application.version}");
            _splashUI.SetActive(true);
            _transitionUI.SetActive(false);
        }

        protected override void FinishSplash()
        {
            base.FinishSplash();
            _splashUI.SetActive(false);
        }

        protected override void StartTransition()
        {
            base.StartTransition();
            _transitionUI.SetActive(true);
        }

        protected override void FinishTransition()
        {
            base.FinishTransition();
            _transitionUI.SetActive(false);
        }
    }
}
