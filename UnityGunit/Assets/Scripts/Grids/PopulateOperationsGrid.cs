using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Grids
{
    public class PopulateOperationsGrid : MonoBehaviour
    {
        [SerializeField]
        GameObject PrefabGridElement;

        void Start()
        {
        }

        void Update()
        {

        }

        public void Populate(int difficulty)
        {
            List<string> operations = new List<string>();
            operations.Add("+");
            operations.Add("-");
            operations.Add("=");
            operations.Add("*");
            operations.Add("/");

            int endIndex = 0;
            switch (difficulty)
            {
                case 1:
                    endIndex = 2;
                    break;
                case 2:
                    endIndex = 3;
                    break;
                case 3:
                    endIndex = 4;
                    break;
            }

            for (int i = 0; i <= endIndex; i++)
            {
                GameObject image = Instantiate(PrefabGridElement, gameObject.transform);
                Text child = image.transform.GetChild(0).gameObject.GetComponent<Text>();
                string operation = operations[i];
                child.text = operation;
            }
        }
    }
}
