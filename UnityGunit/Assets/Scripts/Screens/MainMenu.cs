using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Controllers;
using Utils;

namespace Screens
{
    public class MainMenu : MonoBehaviour
    {
        [SerializeField]
        GameObject PrefabCanvas;

        int defaultDiff = 1;
        int defaultMax = 10;
        int defaultMin = 0;

        void Start()
        {
            ButtonSprites.init();
        }

        void Update()
        {

        }

        public void HandlePlayButtonClicked()
        {
            Destroy(GameObject.FindWithTag("MainMenu"));
            GameObject c = Instantiate(PrefabCanvas);
            gameObject.GetComponent<GameManager>().draw(defaultDiff, c, defaultMin, defaultMax);
        }

        public void HandleSettingsButtonClicked()
        {
            SceneManager.LoadScene("OptionsMenu");
        }
    }
}
