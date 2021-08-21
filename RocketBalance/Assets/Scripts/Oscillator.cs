using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental;
using UnityEngine;

public class Oscillator : MonoBehaviour
{
    private Vector3 startingPos;
    [SerializeField] private Vector3 movementVector;
    [Range(0, 1)] private float movementFactor;

    [SerializeField] [Tooltip("Increasing will make the movement slower")]
    private float period = 2f;

    // Start is called before the first frame update
    void Start()
    {
        startingPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Oscillate();
    }

    private void Oscillate()
    {
        if (period <= Mathf.Epsilon)
        {
            return;
        }

        float cycles = Time.time / period; //continual growth overtime 
        const float tau = Mathf.PI * 2; //tau constant

        float rawSinWave = Mathf.Sin(cycles * tau); //sin wave between -1,1

        movementFactor = (rawSinWave + 1f) / 2f; //altered to make movement between 0 and 1 

        Vector3 offset = movementVector * movementFactor;
        transform.position = startingPos + offset;
    }
}