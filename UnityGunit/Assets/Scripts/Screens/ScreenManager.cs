using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Screens
{
    public static class ScreenManager
    {
        public static void GoToScreen(ScreenNameEnum name)
        {
            switch (name)
            {
                case ScreenNameEnum.MainMenu:
                    SceneManager.LoadScene("MainMenu");
                    break;

                case ScreenNameEnum.Options:
                    SceneManager.LoadScene("OptionsMenu");
                    break;

                case ScreenNameEnum.GameOver:
                    SceneManager.LoadScene("GameOver");
                    break;

                case ScreenNameEnum.TestScene:
                    SceneManager.LoadScene("TestScene");
                    break;
            }
        }
    }
}
