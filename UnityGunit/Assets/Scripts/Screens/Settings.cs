using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using Screens;
using Controllers;

namespace Screens
{
    public class Settings : MonoBehaviour
    {
        [SerializeField]
        GameObject PrefabCanvas;

        [SerializeField]
        InputField minNumInput;

        [SerializeField]
        InputField maxNumInput;

        [SerializeField]
        Dropdown diffDropdown;

        int Difficulty = 0;
        int MaxNum = 0;
        int MinNum = 0;

        void Start()
        {
            minNumInput.onEndEdit.AddListener(delegate { saveMin(minNumInput); });
            maxNumInput.onEndEdit.AddListener(delegate { saveMax(maxNumInput); });
            diffDropdown.onValueChanged.AddListener(delegate { saveDifficulty(diffDropdown); });
        }

        void Update()
        {
        }

        public void saveMin(InputField input)
        {
            MinNum = Int32.Parse(input.text);
        }

        public void saveMax(InputField input)
        {
            MaxNum = Int32.Parse(input.text);
        }

        void saveDifficulty(Dropdown input)
        {
            string value = input.options[input.value].text;
            switch (value)
            {
                case "Easy":
                    Difficulty = 1;
                    break;

                case "Medium":
                    Difficulty = 2;
                    break;

                case "Hard":
                    Difficulty = 3;
                    break;
            }
        }

        public void HandleNextButtonClicked()
        {
            Destroy(GameObject.FindWithTag("Settings"));
            GameObject c = Instantiate(PrefabCanvas);
            gameObject.GetComponent<GameManager>().draw(Difficulty, c, MinNum, MaxNum);
        }
    }
}
