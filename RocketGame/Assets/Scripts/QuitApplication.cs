using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitApplication : MonoBehaviour
{

    // Necessary script to be able to quit our game once it is built.
    void Update()
    {
        //Difference between GetKeyDown and GetKey is that Down runs just for ance and getkey works as long as key pressed.
        if(Input.GetKeyDown(KeyCode.Escape)){
            Debug.Log("Escape pressed");
            Application.Quit();
        }
    }
}
