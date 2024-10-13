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
        sm = GameObject.FindGameObjectWithTag("ScoreManager");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Add money upon collecting coin
        if (collision.CompareTag("Player"))
        {
            sm.GetComponent<ScoreManager>().addMoney(coinValue);
            Destroy(gameObject);
        }
    }
}
