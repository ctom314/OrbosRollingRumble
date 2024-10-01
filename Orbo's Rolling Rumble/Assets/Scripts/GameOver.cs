using System.Collections;
using System.Collections.Generic;
using TMPro;
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
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI coinText;
    public TextMeshProUGUI scoreRatioText;
    public TextMeshProUGUI totalScoreText;

    private PlayerController pc;

    // Start is called before the first frame update
    void Start()
    {
        // Get player controller
        pc = playerParent.GetComponentInChildren<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!pc.isAlive)
        {
            // Unload Maelstrom
            maelstrom.SetActive(false);

            // Show game over screen (Darken screen)
            gameOverScreen.SetActive(true);
            darkenScreen.gameObject.SetActive(true);
            scoreDisplay();

            // Buttons
            quickRestart();
            mainMenuButton();
        }
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
        totalScore = score + (money * pointsPerCoin);

        // Display total score
        totalScoreText.text = "Total: " + totalScore.ToString("000000");
    }

    private void quickRestart()
    {
        // Press R to restart
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("MainLevel");
        }
    }

    private void mainMenuButton()
    {
        // Press Q to return to main menu
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Time.timeScale = 1;
            SceneManager.LoadScene("MainMenu");
        }
    }
}
