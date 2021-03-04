using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] float mainThrust = 1000f;
    [SerializeField] float rotationThrust = 100f;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
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
            rb.AddRelativeForce(Vector3.up * mainThrust * Time.deltaTime);
            //Debug.Log("Space is pressed");
        }
    }

    void ProcessRotation(){

        if(Input.GetKey(KeyCode.A))
        {
            //Debug.Log("Rotating Left");
            Rotate(rotationThrust); // 0,0,1 -> change z axis.
        }
        // else cond used because users shouldn't press a and d at the same time. Cant go right and left at the sime time right :)
        else if(Input.GetKey(KeyCode.D)){
            //Debug.Log("Rotating Right");
            Rotate(-rotationThrust); // 0,0,-1 -z axis
        }
    }



    // ctrl + . over copied line of code to make a new method.
    // method for rotating the rocket.
    private void Rotate(float rotationDirection)
    {
        transform.Rotate(Vector3.forward * rotationDirection * Time.deltaTime);
    }
}
