using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public float score;
    public float money;
    public float scoreIncrementRate;

    // Multipliers
    public float scoreMultiplier = 1f;
    public float moneyMultiplier = 1f;

    // UI
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI scoreShadow;
    public TextMeshProUGUI scoreMultiplierText;
    public TextMeshProUGUI scoreMultiplierShadow;

    public TextMeshProUGUI moneyText;
    public TextMeshProUGUI moneyShadow;
    public TextMeshProUGUI moneyMultiplierText;
    public TextMeshProUGUI moneyMultiplierShadow;

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
        score += (scoreIncrementRate * scoreMultiplier) * Time.deltaTime;
        updateScore();
    }

    public void addMoney(int m)
    {
        // Take the coin value and add it to money
        money += m * moneyMultiplier;
        updateMoney();
    }

    private void updateMoney()
    {
        moneyText.text = "$" + money.ToString("0.00");
        moneyShadow.text = "$" + money.ToString("0.00");

        // If multiplier is greater than 1, show it
        if (moneyMultiplier > 1)
        {
            // Calculate percentage
            float moneyPercentage = (moneyMultiplier - 1) * 100;

            moneyMultiplierText.gameObject.SetActive(true);
            moneyMultiplierShadow.gameObject.SetActive(true);

            moneyMultiplierText.text = "+" + moneyPercentage.ToString() + "%";
            moneyMultiplierShadow.text = "+" + moneyPercentage.ToString() + "%";
        }
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

        // If multiplier is greater than 1, show it
        if (scoreMultiplier > 1)
        {
            // Calculate percentage
            float scorePercentage = (scoreMultiplier - 1) * 100;

            scoreMultiplierText.gameObject.SetActive(true);
            scoreMultiplierShadow.gameObject.SetActive(true);

            scoreMultiplierText.text = "+" + scorePercentage.ToString() + "%";
            scoreMultiplierShadow.text = "+" + scorePercentage.ToString() + "%";
        }
    }

    // Multipliers
    public void addMoneyMultiplier(float m)
    {
        moneyMultiplier += m;
        updateMoney();
    }

    public void addScoreMultiplier(float m)
    {
        scoreMultiplier += m;
        updateScore();
    }
}
