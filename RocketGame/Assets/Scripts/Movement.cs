﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        ProcessThrust();
        ProcessRotation();
    }

    void ProcessThrust()
    {
        if(Input.GetKey(KeyCode.Space)){
            Debug.Log("Pressed Space");
        }
    }

    void ProcessRotation(){

        if(Input.GetKey(KeyCode.A)){
            Debug.Log("Rotating Left");
        }
        // else cond used because users shouldn't press a and d at the same time. Cant go right and left at the sime time right :)
        else if(Input.GetKey(KeyCode.D)){
            Debug.Log("Rotating Right");
        }
    }
}
