using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D playerRigidBody;
    private bool inAir;
    private float startRollSpeed;

    // For restricting player from going above the screen
    private Vector2 topOfScreen;

    // For limiting jumps
    private int maxJumps;
    private int numJumps;

    public GameManager gameManager;
    public bool isAlive;
    public float rollSpeed;
    public float maxRollSpeed;
    public float jumpForce;

    // Start is called before the first frame update
    void Start()
    {
        // Get player rigidbody
        playerRigidBody = GetComponent<Rigidbody2D>();

        isAlive = true;

        // Only allow 1 jump
        maxJumps = 1;
        numJumps = 1;

        // Ensure roll speed is set properly
        startRollSpeed = rollSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        // Only allow movement when the player is alive
        if (isAlive)
        {
            movePlayer();
            LimitRollSpeed();
            jump();
            fallFaster();
        }

        RestrictPlayerY();
    }

    private void movePlayer()
    {
        if (!inAir)
        {
            // Apply toque to the player to simulate rolling
            playerRigidBody.AddTorque(-1f * rollSpeed);
        }
    }

    private void LimitRollSpeed()
    {
        // Check if the player's current speed exceeds the maximum allowed speed
        if (Mathf.Abs(playerRigidBody.velocity.x) > maxRollSpeed)
        {
            // Scale the velocity to maintain it at the maximum speed
            playerRigidBody.velocity = new Vector2(Mathf.Sign(playerRigidBody.velocity.x) * maxRollSpeed, playerRigidBody.velocity.y);
        }
    }

    private void jump()
    {
        // If the player presses the space bar, jump if the player can jump
        if (Input.GetKeyDown(KeyCode.Space) && numJumps <= maxJumps)
        {
            // Move the player up
            playerRigidBody.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);

            // Increment the number of jumps
            numJumps++;

            inAir = true;

        }
    }

    private void fallFaster()
    {
        // If the S key is pressed in air, fall faster
        if (Input.GetKey(KeyCode.S))
        {
            playerRigidBody.gravityScale = 3;
        }
        else
        {
            playerRigidBody.gravityScale = 1;
        }
    }

        private void OnCollisionEnter2D(Collision2D collision)
    {
        // If the player collides with the ground, reset the number of jumps
        if (collision.gameObject.CompareTag("Grounded"))
        {
            numJumps = 1;
            inAir = false;
        }

    }

    private void ResetSpeed()
    {
        rollSpeed = startRollSpeed;
    }

    private void RestrictPlayerY()
    {
        // Get where top of screen is
        topOfScreen = Camera.main.ViewportToWorldPoint(new Vector2(0, 1));

        // If player's position exceeds that, prevent player from going above
        if (transform.position.y > topOfScreen.y)
        {
            // Bounce the player back down
            playerRigidBody.velocity = new Vector2(playerRigidBody.velocity.x, -Mathf.Abs(playerRigidBody.velocity.y));
        }
    }

    public void KillPlayer()
    {
        transform.parent.gameObject.SetActive(false);
        isAlive = false;

        // Cancel powerup effect if player has one
        gameManager.cancelSlowTime();
    }
}
