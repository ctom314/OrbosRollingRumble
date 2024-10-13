using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public GameObject gameOverScreen;
    public GameObject playerParent;
    public GameObject darkenScreen;
    public GameObject maelstrom;

    // Score calculation needed vars
    public ScoreManager scoreManager;
    public int pointsPerCoin;

    // UI
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI coinText;
    public TextMeshProUGUI scoreRatioText;
    public TextMeshProUGUI totalScoreText;

    private PlayerController pc;
    private bool highscoreCalculated;
    private bool displayUpdated;

    // Top 5 Highscores colors corresponding to their position
    private List<Color32> highscoreColors = new List<Color32>()
    {
        // 1st: Gold
        new Color32(255, 220, 0, 255),

        // 2nd: Silver
        new Color32(204, 204, 204, 255),

        // 3rd: Bronze (Brownish color)
        new Color32(226, 102, 0, 255),

        // 4th and 5th: Gray (Darker than silver)
        new Color32(156, 156, 156, 255),
        new Color32(156, 156, 156, 255),
    };

    // Start is called before the first frame update
    void Start()
    {
        highscoreCalculated = false;
        displayUpdated = false;

        pc = playerParent.GetComponentInChildren<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!pc.isAlive)
        {
            // Unload Maelstrom
            maelstrom.SetActive(false);

            // Show game over screen, darken screen, and display score
            if (!displayUpdated)
            {
                gameOverScreen.SetActive(true);
                darkenScreen.gameObject.SetActive(true);
                scoreDisplay();

                displayUpdated = true;
            }

            // Calculate highscores
            if (!highscoreCalculated)
            {
                // Calculate total score and update highscores
                float totalScore = calculateTotalScore();
                updateHighscores(totalScore);

                // Get highscore position for total score display
                int scorePos = calculateHighScorePosition(totalScore);

                // Change Total Score text based on highscore position
                if (scorePos != 0)
                {
                    totalScoreText.text = "Total: " + totalScore.ToString("000000") + " (#" + scorePos + ")";
                    totalScoreText.color = highscoreColors[scorePos - 1];
                }

                highscoreCalculated = true;
            }

            // Buttons
            quickRestart();
            mainMenuButton();
        }
    }

    private float calculateTotalScore()
    {
        float totalScore;
        float score = scoreManager.score;
        float money = scoreManager.money;

        // Calculate total score
        totalScore = score + (money * pointsPerCoin);

        return totalScore;
    }

    private void scoreDisplay()
    {
        float totalScore;
        float score = scoreManager.score;
        float money = scoreManager.money;

        // Display score and coin count
        scoreText.text = "Score: " + score.ToString("000000");
        coinText.text = "$" + money.ToString("0.00");
        scoreRatioText.text = "x" + pointsPerCoin;

        // Calculate total score
        totalScore = calculateTotalScore();

        // Display total score
        totalScoreText.text = "Total: " + totalScore.ToString("000000");
    }

    private void quickRestart()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("MainLevel");
        }
    }

    private void mainMenuButton()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Time.timeScale = 1;
            SceneManager.LoadScene("MainMenu");
        }
    }

    private void updateHighscores(float score)
    {
        // Number of high scores to keep track of
        int numberOfScores = 5;
        int[] highScores = new int[numberOfScores];

        // Get highscores
        for (int i = 0; i < numberOfScores; i++)
        {
            highScores[i] = PlayerPrefs.GetInt("Highscore" + i, 0);
        }

        // Calculate if score is a high score
        for (int i = 0; i < numberOfScores; i++)
        {
            if (score > highScores[i])
            {
                // Shift lower scores down
                for (int j = numberOfScores - 1; j > i; j--)
                {
                    highScores[j] = highScores[j - 1];
                }

                // Insert new score. Round score since highscore is rounded
                highScores[i] = (int)Math.Round((double)score);
                break;
            }
        }

        // Save updated highscores
        for (int i = 0; i < numberOfScores; i++)
        {
            PlayerPrefs.SetInt("Highscore" + i, highScores[i]);
        }

        PlayerPrefs.Save();
    }

    private int calculateHighScorePosition(float score)
    {
        // Compare score to highscores
        for (int i = 0; i < 5; i++)
        {
            int highScore = PlayerPrefs.GetInt("Highscore" + i, 0);

            // Round score since highscore is rounded
            score = (int)Math.Round((double)score);

            if (score >= highScore)
            {
                // Position where score should be inserted
                return i + 1;
            }
        }

        // Score is not high enough
        return 0;
    }
}
