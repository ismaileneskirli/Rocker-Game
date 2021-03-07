using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OscillatorZ : MonoBehaviour
{
    // all explanations for this class is in Oscillator.cs

    Vector3 startingPosition ;
    [SerializeField] Vector3 movementVector;
    float movementFactor;
    float period = 5f;
    // Start is called before the first frame update
    void Start()
    {

        startingPosition = transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        // since numbers are not dividable by 0 it is protection. İf period smaller than epsilon do nothing below.
        if(period <= Mathf.Epsilon) {return;}

        float cycles = Time.time / period ;
        float tau = Mathf.PI * 2;
        float sinWave = Mathf.Sin(cycles * tau);

        movementFactor = (sinWave+1f)/2f;
        Vector3 offset =movementFactor * movementVector;
        transform.position =  startingPosition + offset;
    }
}
