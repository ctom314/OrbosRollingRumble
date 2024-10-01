using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreMultiplier : MonoBehaviour
{
    public float addValue = 0.25f;

    // Score Manager
    private GameObject sm;

    // Start is called before the first frame update
    void Start()
    {
        // Get Score Manager
        sm = GameObject.FindGameObjectWithTag("ScoreManager");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            sm.GetComponent<ScoreManager>().addScoreMultiplier(addValue);
            Destroy(gameObject);
        }
    }
}
