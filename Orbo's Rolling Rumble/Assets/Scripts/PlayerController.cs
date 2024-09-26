using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D playerRigidBody;
    private float inputHorizontal;
    private bool isAlive;
    private bool inAir;
    private float startRollSpeed;

    // For restricting player from going above the screen
    private Vector2 topOfScreen;

    // For limiting jumps
    private int maxJumps;
    private int numJumps;

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
        resetLevel();
    }

    private void movePlayer()
    {
        // If the player is not in the air, allow the player to move left/right
        if (!inAir)
        {
            // Get Left/Right input
            inputHorizontal = Input.GetAxis("Horizontal");

            // Apply toque to the player to simulate rolling
            playerRigidBody.AddTorque(-inputHorizontal * rollSpeed);
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
        if (Input.GetKey(KeyCode.S) && inAir)
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

    // Debugging purposes
    private void resetLevel()
    {
        // If the player presses the R key, restart the level
        if (Input.GetKeyDown(KeyCode.R))
        {
            ResetSpeed();
            SceneManager.LoadScene("MainLevel");
        }
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

    // TODO: Be able to kill player and end game in KillPlayer.cs
    public void KillPlayer()
    {
        // End the game
        isAlive = false;
    }
}
