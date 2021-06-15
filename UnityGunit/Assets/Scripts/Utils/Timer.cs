using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Utils
{
    public class Timer : MonoBehaviour
    {
        public float remainingTime;
        public bool running = false;

        void Update()
        {
            if (running == true)
            {
                remainingTime -= Time.deltaTime;
            }
            if (running == true && remainingTime <= 0f)
            {
                Stop();
                gameObject.GetComponent<Button>().clearField();
            }
        }

        public void Run(float time)
        {
            remainingTime = time;
            running = true;
        }

        public void Stop()
        {
            running = false;
        }
    }
}
