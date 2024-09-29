using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowTimePowerup : MonoBehaviour
{
    private GameObject gameManager;
    private GameManager gmScript;

    // Start is called before the first frame update
    void Start()
    {
        // Get gm and script
        gameManager = GameObject.Find("GameManager");
        gmScript = gameManager.GetComponent<GameManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            // Allow collecting powerup if not already at max capacity
            if (gmScript.clockPowerupCount < gmScript.maxPowerupCount)
            {
                // Increment powerup count
                gmScript.incClockPowerup();

                Destroy(gameObject);
            }
        }
    }
}
