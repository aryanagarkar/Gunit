using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Grids
{
    public class PopulateNumberGrid : MonoBehaviour
    {
        [SerializeField]
        GameObject PrefabGridElement;

        void Start()
        {

        }

        void Update()
        {

        }

        public void Populate(int difficulty, int min, int max)
        {
            int numberToCreate = 13;
            for (int i = 0; i <= numberToCreate; i++)
            {
                GameObject image = Instantiate(PrefabGridElement, gameObject.transform);
                Text child = image.transform.GetChild(0).gameObject.GetComponent<Text>();
                int num = (int)UnityEngine.Random.Range(min, max);
                child.text = num.ToString();
            }
        }
    }
}
