using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public GameObject gameOverScreen;
    public GameObject player;

    // Score calculation needed vars
    public Collectables scoreManager;
    public int pointsPerCoin;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI coinText;
    public TextMeshProUGUI scoreRatioText;
    public TextMeshProUGUI totalScoreText;

    private PlayerController pc;

    // Start is called before the first frame update
    void Start()
    {
        // Get player controller
        pc = player.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!pc.isAlive)
        {
            // Show game over screen
            gameOverScreen.SetActive(true);
            scoreDisplay();
        }
    }

    private void scoreDisplay()
    {
        float totalScore;
        float score = scoreManager.score;
        float money = scoreManager.money;

        // Display score and coin count
        scoreText.text = "Score: " + score.ToString("000000");
        coinText.text = "$" + money.ToString();
        scoreRatioText.text = "x" + pointsPerCoin;

        // Calculate total score
        totalScore = score + (money * pointsPerCoin);

        // Display total score
        totalScoreText.text = "Total: " + totalScore.ToString("000000");
    }
}
