using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public int coinValue;

    // Score Manager
    private GameObject sm;

    // Start is called before the first frame update
    void Start()
    {
        // Get Score Manager
        sm = GameObject.FindGameObjectWithTag("ScoreManager");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // If the player collects a coin, add it to money count
        if (collision.CompareTag("Player"))
        {
            sm.GetComponent<ScoreManager>().addMoney(coinValue);
            Destroy(gameObject);
        }
    }
}
