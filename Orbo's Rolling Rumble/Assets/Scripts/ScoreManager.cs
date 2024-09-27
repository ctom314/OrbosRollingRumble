using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Collectables : MonoBehaviour
{
    public float score;
    public float money;
    public float scoreIncrementRate;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI moneyText;
    public PlayerController playerController;

    // Start is called before the first frame update
    void Start()
    {
        updateScore();
        updateMoney();
    }

    // Update is called once per frame
    void Update()
    {
        // Increment score when player is alive
        if (playerController.isAlive)
        {
            incrementScore();
        }
    }

    private void incrementScore()
    {
        // Increment score per second
        score += scoreIncrementRate * Time.deltaTime;
        updateScore();
    }

    public void addMoney(int m)
    {
        // Take the coin value and add it to money
        money += m;
        updateMoney();
    }

    private void updateMoney()
    {     
        moneyText.text = "$" + money.ToString();
    }

    private void updateScore()
    {
        // Ensure there are leading zeros
        scoreText.text = "Score: " + score.ToString("000000");
    }
}
