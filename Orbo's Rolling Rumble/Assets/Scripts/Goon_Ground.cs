using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Goon_Ground : MonoBehaviour
{
    private Rigidbody2D gRigidbody;
    private float direction;

    public Transform player;
    public float rollSpeed;
    public float maxRollSpeed;

    // Start is called before the first frame update
    void Start()
    {
        gRigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Only target player when enemy is on screen
        if (isOnScreen())
        {
            TargetPlayer();
        }

        LimitRollSpeed();
    }

    private bool isOnScreen()
    {
        // Check if the enemy is on the screen
        Vector2 screenPos = Camera.main.WorldToViewportPoint(transform.position);
        return (screenPos.x > 0 && screenPos.x < 1 && screenPos.y > 0 && screenPos.y < 1);
    }

    private void TargetPlayer()
    {
        if (player != null)
        {
            // Get the direction to the player
            direction = Mathf.Sign(player.position.x - transform.position.x);

            // Roll towards the player
            gRigidbody.AddTorque((-1 * direction) * rollSpeed);
        }
    }

    // Same as player, but for enemy
    private void LimitRollSpeed()
    {
        if (Mathf.Abs(gRigidbody.velocity.x) > maxRollSpeed)
        {
            gRigidbody.velocity = new Vector2(Mathf.Sign(gRigidbody.velocity.x) * maxRollSpeed, gRigidbody.velocity.y);
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            // TODO: Implement player death
            // DEBUG: Restart level
            SceneManager.LoadScene("MainLevel");
        }
    }
}
