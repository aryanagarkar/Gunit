using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Controllers;

namespace Screens
{
    public class GameOverScene : MonoBehaviour
    {
        [SerializeField]
        Text scoreText;

        void Start()
        {
            scoreText.text = "Score: " + Tracker.Score;
        }

        void Update()
        {

        }
    }
}
