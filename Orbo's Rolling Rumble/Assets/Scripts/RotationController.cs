using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationController : MonoBehaviour
{
    public Transform bodyObject;
    public bool rotateClockwise = true;
    public float initialRotationSpeed = 90;
    public float maxRotationSpeed = 720;
    public float increaseRate = 180;

    private float rotationSpeed;

    // Start is called before the first frame update
    void Start()
    {
        rotationSpeed = initialRotationSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        // Sync position with body object
        transform.position = bodyObject.position;

        // Increase rotation speed over time
        if (rotationSpeed < maxRotationSpeed)
        {
            rotationSpeed += increaseRate * Time.deltaTime;

            // Prevent rotation speed from exceeding max
            if (rotationSpeed > maxRotationSpeed)
            {
                rotationSpeed = maxRotationSpeed;
            }
        }

        // Rotate face at fixed speed
        if (rotateClockwise)
        {
            transform.Rotate(Vector3.forward, -rotationSpeed * Time.deltaTime);

        }
        else
        {
            transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);
        }
    }
}
