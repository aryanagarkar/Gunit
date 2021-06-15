using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Screens;
using Controllers;

namespace Sprites
{
    public class EndGame : MonoBehaviour
    {
        void Start()
        {

        }

        void Update()
        {

        }

        public void HandleEndGameButtonClicked()
        {
            Tracker.calculateScore();
            ScreenManager.GoToScreen(ScreenNameEnum.GameOver);
        }
    }
}
