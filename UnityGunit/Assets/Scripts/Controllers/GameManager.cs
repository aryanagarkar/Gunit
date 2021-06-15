using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using Grids;
using Utils;

namespace Controllers
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField]
        GameObject prefabButton;

        [SerializeField]
        GameObject prefabInputField;

        [SerializeField]
        GameObject prefabDoneButton;

        [SerializeField]
        GameObject prefabEndGameButton;

        [SerializeField]
        GameObject canvas;


        void Start()
        {
            Tracker.Init();
        }

        public void draw(int difficulty, GameObject canvas, int min, int max)
        {
            GameObject field = Instantiate(prefabInputField, canvas.transform);
            field.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, -60);

            GameObject NumPanel = canvas.transform.GetChild(0).gameObject;
            NumPanel.GetComponent<PopulateNumberGrid>().Populate(difficulty, min, max);

            GameObject OperationsPanel = canvas.transform.GetChild(1).gameObject;
            OperationsPanel.GetComponent<PopulateOperationsGrid>().Populate(difficulty);

            GameObject go = Instantiate(prefabButton, canvas.transform);
            go.GetComponentInChildren<Text>().text = "Go";
            go.GetComponent<RectTransform>().anchoredPosition = new Vector2(180, 170);

            GameObject back = Instantiate(prefabButton, canvas.transform);
            back.GetComponentInChildren<Text>().text = "Back";
            back.GetComponentInChildren<Text>().fontSize = 15;
            back.GetComponent<RectTransform>().anchoredPosition = new Vector2(-180, 170);

            GameObject done = Instantiate(prefabDoneButton, canvas.transform);
            done.GetComponent<RectTransform>().anchoredPosition = new Vector2(-250, 30);
            GameObject endGame = Instantiate(prefabEndGameButton, canvas.transform);
            endGame.GetComponent<RectTransform>().anchoredPosition = new Vector2(-50, 30);
        }

        public void nextRound()
        {
            foreach (GameObject obj in GameObject.FindGameObjectsWithTag("Button"))
            {
                Image image = obj.GetComponent<Image>();
                int n;
                if (int.TryParse(obj.transform.GetChild(0).gameObject.GetComponent<Text>().text, out n) == true)
                {
                    if (image.overrideSprite == ButtonSprites.buttonSpriteGray)
                    {
                        image.overrideSprite = null;
                    }
                    else if (image.overrideSprite == ButtonSprites.buttonSpriteBlue)
                    {
                        image.overrideSprite = ButtonSprites.buttonSpriteGray;
                    }
                }
            }
        }
    }
}
