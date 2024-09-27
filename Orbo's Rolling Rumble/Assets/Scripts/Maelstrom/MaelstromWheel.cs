using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MaelstromWheel : MonoBehaviour
{
    private Rigidbody2D gRigidbody;
    private float rollSpeed;
    private float maxRollSpeed;

    public Maelstrom maelstrom;

    // Start is called before the first frame update
    void Start()
    {
        gRigidbody = GetComponent<Rigidbody2D>();

        // Get values from Maelstrom
        rollSpeed = maelstrom.rollSpeed;
        maxRollSpeed = maelstrom.maxRollSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        // Always roll
        Roll();
        LimitRollSpeed();
    }

    private void Roll()
    {
        // Roll right
        gRigidbody.AddTorque(-rollSpeed);
    }

    private void LimitRollSpeed()
    {
        if (Mathf.Abs(gRigidbody.velocity.x) > maxRollSpeed)
        {
            gRigidbody.velocity = new Vector2(Mathf.Sign(gRigidbody.velocity.x) * maxRollSpeed, gRigidbody.velocity.y);
        }
    }
}
