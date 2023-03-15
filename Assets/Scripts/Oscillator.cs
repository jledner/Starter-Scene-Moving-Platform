using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscillator : MonoBehaviour
{
    [Header("Movement Parameters")]
    public Vector3 movementAxis;
    public float movementSpeed;
    public float movementDistance;

    [Header("Movement Positions")]
    public Vector3 startingPosition;
    public Vector3 posEnd;
    public Vector3 negEnd;

    [Header("Rotation Parameters")]
    public bool rotates;
    public float rotationSpeed;
    public Vector3 rotationAxis = Vector3.up;

    private Vector3 direction;
    // Start is called before the first frame update
    void Start()
    {
        //the direction of movement
        direction = movementAxis.normalized;

        //precompute positions
        startingPosition = transform.position;
        posEnd = transform.position + (direction * movementDistance);
        negEnd = transform.position - (direction * movementDistance);
        

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //if we reach bounds of movement, reverse direction vector
        if (Vector3.Distance(transform.position, posEnd) <= 0.1f || Vector3.Distance(transform.position, negEnd) <= 0.1f)
        {
            direction *= -1;
            rotationSpeed *= -1;
        }
        transform.Translate(direction * movementSpeed * Time.deltaTime, Space.World);
        if (rotates)
            transform.Rotate(rotationAxis, rotationSpeed);
    }
}
