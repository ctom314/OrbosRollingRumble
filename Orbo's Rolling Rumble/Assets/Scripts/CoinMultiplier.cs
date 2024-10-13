using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinMultiplier : MonoBehaviour
{
    // Multiplier value as decimal (25% = 0.25)
    public float addValue = 0.25f;

    // Score Manager
    private GameObject sm;

    // Start is called before the first frame update
    void Start()
    {
        sm = GameObject.FindGameObjectWithTag("ScoreManager");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Add money multiplier to player upon collection
        if (collision.CompareTag("Player"))
        {
            sm.GetComponent<ScoreManager>().addMoneyMultiplier(addValue);
            Destroy(gameObject);
        }
    }
}
