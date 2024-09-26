using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowTimePowerup : MonoBehaviour
{
    private GameObject player;
    private GameObject maelstrom;
    private GameObject gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager");

        // Get player obj from GameManager
        player = gameManager.GetComponent<GameManager>().player;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            decreaseSpeed();
            Destroy(gameObject);
        }
    }

    private void decreaseSpeed()
    {
        // Half the speed of the player and Maelstrom
        if (player != null)
        {
            player.GetComponent<PlayerController>().rollSpeed /= 2;
            // Maelstrom speed goes here
        }
    }
}
