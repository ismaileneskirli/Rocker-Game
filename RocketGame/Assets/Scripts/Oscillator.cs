using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscillator : MonoBehaviour
{

    //This script is created for making obstacles move.
    Vector3 startingPosition;
    [SerializeField] Vector3 movementVector;
    [SerializeField] [Range(0,1)] float movementFactor; // Movement factor can be set from 0 to 1
    [SerializeField] float period = 5f;

    // Start is called before the first frame update
    void Start()
    {
        startingPosition = transform.position;
        Debug.Log(startingPosition);

    }

    // Update is called once per frame
    void Update()
    {

        //Genereating sinus wave in here.
        float cycles = Time.time / period ; // every 2 sec 1 cycle is finished. period equals to 2. cycles var is contiunally growing over time..
        const float tau = Mathf.PI * 2; // tau equals to pi sin(tau) = 1, tau*cycles gives the ratio, every 2 sec sin equals 1. then -1 goes on.
        float rawSinWave = Mathf.Sin(cycles * tau);
        //recalculated to go from 0 to 1, but it is not essential, it is just cleaner.
        movementFactor = (rawSinWave + 1f)/2 ; // i added 1 because sin is between -1, 1. With +1f now it is between 0 and 2 and. Divide it by 2. İt is now in ranget between 0 and 1.

        Vector3 offset = movementFactor * movementVector;
        transform.position = offset + startingPosition;
    }
}
