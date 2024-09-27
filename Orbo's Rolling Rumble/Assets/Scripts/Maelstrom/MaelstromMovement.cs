using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaelstromMovement : MonoBehaviour
{
    public Transform leftWheel;
    public Transform rightWheel;

    // Update is called once per frame
    void Update()
    {
        // Get midpoint between the wheels
        Vector3 midpoint = (leftWheel.position + rightWheel.position) / 2;

        // Body follows X position of wheels
        transform.position = new Vector3(midpoint.x, transform.position.y, transform.position.z);

        // Prevent rotation
        transform.rotation = Quaternion.identity;
    }
}
