using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goon_Flying : MonoBehaviour
{
    private bool moveUp;
    private float initPos_y;

    public bool startMovingDown;
    public int speedRandomMin;
    public int speedRandomMax;
    public int offsetRandomMin;
    public int offsetRandomMax;

    // Start is called before the first frame update
    void Start()
    {
        // Determine starting direction
        if (startMovingDown)
        {
            moveUp = false;
        }
        else
        {
            moveUp = true;
        }

        initPos_y = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        // Only move the enemy if it is on screen
        if (isOnScreen())
        {
            movement();
        }
    }
    private bool isOnScreen()
    {
        // Check if the enemy is on the screen
        Vector2 screenPos = Camera.main.WorldToViewportPoint(transform.position);
        return (screenPos.x > 0 && screenPos.x < 1 && screenPos.y > 0 && screenPos.y < 1);
    }

    private void movement()
    {
        // Get random vars
        float offset = Random.Range(offsetRandomMin, offsetRandomMax + 1);
        float speed = Random.Range(speedRandomMin, speedRandomMax + 1);

        if (moveUp)
        {
            // Move the enemy up
            transform.Translate(Vector2.up * speed * Time.deltaTime);

            // Check if the enemy has reached or exceeded the top boundary
            if (transform.position.y >= initPos_y + offset)
            {
                moveUp = false;
            }
        }

        else
        {
            // Move the enemy down
            transform.Translate(Vector2.down * speed * Time.deltaTime);

            // Check if the enemy has reached or exceeded the bottom boundary
            if (transform.position.y <= initPos_y - offset)
            {
                moveUp = true;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // If enemy hits the ground, go up
        if (collision.gameObject.CompareTag("Grounded"))
        {
            moveUp = true;
        }
    }
}
