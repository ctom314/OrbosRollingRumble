using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KillPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // If the player collides with the object, End game
        if (collision.gameObject.tag == "Player")
        {
            // Temp: restart the level
            SceneManager.LoadScene("MainLevel");
        }
    }
}
