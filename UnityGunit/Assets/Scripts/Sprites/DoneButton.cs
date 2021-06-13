using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Controllers;

public class DoneButton : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void HandleDoneButtonClicked()
    {
        Camera.main.GetComponent<GameManager>().nextRound();
    }
}
