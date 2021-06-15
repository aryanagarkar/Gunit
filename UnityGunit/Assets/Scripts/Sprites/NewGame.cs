using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Screens;
using Controllers;

namespace Sprites
{
    public class NewGame : MonoBehaviour
    {
        void Start()
        {

        }

        void Update()
        {

        }

        public void HandleNewGameButtonClicked()
        {
            Tracker.clear();
            ScreenManager.GoToScreen(ScreenNameEnum.MainMenu);
        }
    }
}
