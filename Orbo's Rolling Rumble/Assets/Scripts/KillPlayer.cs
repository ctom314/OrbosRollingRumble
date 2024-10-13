using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KillPlayer : MonoBehaviour
{
    // Whether the object uses a trigger to kill the player or not
    public bool useTrigger;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!useTrigger)
        { 
            if (collision.gameObject.tag == "Player")
            {
                // Kill player
                collision.gameObject.GetComponentInChildren<PlayerController>().KillPlayer();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (useTrigger)
        {
            if (collision.gameObject.tag == "Player")
            {
                // Kill player
                collision.gameObject.GetComponentInChildren<PlayerController>().KillPlayer();
            }
        }
    }
}
