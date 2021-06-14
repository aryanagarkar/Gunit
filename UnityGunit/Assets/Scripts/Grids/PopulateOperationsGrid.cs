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

        List<string> operations;

        void Awake()
        {
            operations = new List<string>();
            operations.Add("+");
            operations.Add("-");
            operations.Add("=");
            operations.Add("*");
            operations.Add("/");
        }

        void Update()
        {

        }

        public void Populate(int difficulty)
        {
            int endIndex = difficulty + 1;

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
