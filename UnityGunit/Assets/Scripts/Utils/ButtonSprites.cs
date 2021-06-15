using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Utils
{
    public static class ButtonSprites
    {
        public static Sprite buttonSpriteBlue;

        public static Sprite buttonSpriteGray;

        public static void init()
        {
            buttonSpriteBlue = Resources.Load<Sprite>("number_button_Blue");
            buttonSpriteGray = Resources.Load<Sprite>("number_button_Gray");
        }
    }
}
