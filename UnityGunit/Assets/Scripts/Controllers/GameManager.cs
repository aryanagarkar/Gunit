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
        //private List<GameObject> greyedOutCells;

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
            //greyedOutCells = new List<GameObject>();
            Tracker.Init();
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
                        /*greyedOutCells.Add(obj);
                        if (!greyedOutCells.Contains(obj))
                        {
                            image.overrideSprite = null;
                        } */
                        image.overrideSprite = null;
                    }
                    else if (image.overrideSprite == ButtonSprites.buttonSpriteBlue)
                    {
                        image.overrideSprite = ButtonSprites.buttonSpriteGray;
                    }
                }
            }
        }

        public void draw(int difficulty, GameObject canvas, int min, int max)
        {
            Instantiate(prefabInputField, canvas.transform);
            GameObject NumPanel = canvas.transform.GetChild(0).gameObject;
            NumPanel.GetComponent<PopulateNumberGrid>().Populate(difficulty, min, max);

            GameObject OperationsPanel = canvas.transform.GetChild(1).gameObject;
            OperationsPanel.GetComponent<PopulateOperationsGrid>().Populate(difficulty);

            GameObject b = Instantiate(prefabButton, canvas.transform);
            b.GetComponentInChildren<Text>().text = "Go";

            Instantiate(prefabDoneButton, canvas.transform);
            Instantiate(prefabEndGameButton, canvas.transform);
        }
    }
}
