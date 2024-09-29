using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public float score;
    public float money;
    public float scoreIncrementRate;

    // UI
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI scoreShadow;
    public TextMeshProUGUI moneyText;
    public TextMeshProUGUI moneyShadow;

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
        moneyShadow.text = "$" + money.ToString();
    }

    private void updateScore()
    {
        // If score is over 999999, cap it
        if (score > 999999)
        {
            score = 999999;
        }

        // Ensure there are leading zeros
        scoreText.text = "Score: " + score.ToString("000000");
        scoreShadow.text = "Score: " + score.ToString("000000");
    }
}
