using System.Collections.Generic;
using UnityEngine;
using Moblik.Core.Singleton;

namespace Screens
{
    public class ScreenManager : Singleton<ScreenManager>
    {
        public List<ScreenBase> screenBases;
        public ScreenType startScreen = ScreenType.MainPanel;

        private ScreenBase _currentScreenBase;

        protected override void Awake()
        {
            base.Awake();
            HideAll();
        }

        private void Start()
        {
            ShowByType(startScreen);
        }

        public void ShowByType(ScreenType type)
        {
            if (_currentScreenBase != null) _currentScreenBase.Hide();

            var nextScreen = screenBases.Find(i => i.screenType == type);

            nextScreen.Show();
            _currentScreenBase = nextScreen;
        }

        public void HideAll()
        {
            screenBases.ForEach(i =>  i.Hide());
        }
    }
}