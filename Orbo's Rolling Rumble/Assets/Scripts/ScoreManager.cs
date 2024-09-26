using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Collectables : MonoBehaviour
{
    public float score;
    public float money;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI moneyText;

    // Start is called before the first frame update
    void Start()
    {
        UpdateMoney();
        UpdateScore();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void addMoney(int m)
    {
        // Take the coin value and add it to money
        money += m;
        UpdateMoney();
    }

    private void UpdateMoney()
    {     
        moneyText.text = "$" + money.ToString();
    }

    private void UpdateScore()
    {
        // Ensure there are leading zeros
        scoreText.text = "Score: " + score.ToString("000000");
    }
}
