using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class HighscoresManager : MonoBehaviour
{
    public TextMeshProUGUI[] highscoreTexts;

    // UI for clearing highscores
    public GameObject warning;
    public Button clearButton;
    public Button backButton;

    // Timer vars for disabling clear button temporarily after first press
    private bool canClearScores = true;
    private float clearButtonPressDelay = 3f;
    public bool canGoBack = true;

    public int scoreClearButtonPresses = 0;

    // Start is called before the first frame update
    void Start()
    {
        // Update highscores
        updateHighscores();
    }

    // Update is called once per frame
    void Update()
    {
        // Enable clear button to be pressed with keyboard key
        if (canClearScores && Input.GetKeyDown(KeyCode.C))
        {
            clearHighscores();
        }
    }

    public void updateHighscores()
    {
        // Update each highscore UI element with the corresponding highscore
        for (int i = 0; i < highscoreTexts.Length; i++)
        {
            // Default highscore is 0 (Acts as no highscore)
            int score = PlayerPrefs.GetInt("Highscore" + i, 0);

            if (score != 0)
            {
                // If highscore exists, display it
                highscoreTexts[i].text = "#" + (i + 1) + ": " + score.ToString("000000");
            }
            else
            {
                // Display dashes if no highscore
                highscoreTexts[i].text = "#" + (i + 1) + ": " + "----------";
            }
        }
    }

    public void clearHighscores()
    {
        if (scoreClearButtonPresses == 0)
        {
            // Disable clear button for a few seconds after first press
            StartCoroutine(disableClearButton());

            scoreClearButtonPresses++;
        }

        else if (scoreClearButtonPresses >= 1)
        {
            // Clear highscores and update UI after second press
            for (int i = 0; i < highscoreTexts.Length; i++)
            {
                PlayerPrefs.DeleteKey("Highscore" + i);
            }

            PlayerPrefs.Save();
            updateHighscores();

            warning.SetActive(false);

            // Disable clear button since highscores are cleared
            clearButton.interactable = false;
        }
    }

    public IEnumerator disableClearButton()
    {
        canClearScores = false;
        canGoBack = false;

        // Disable the buttons
        clearButton.interactable = false;
        backButton.interactable = false;

        // Show warning message
        warning.SetActive(true);

        // Wait for a few seconds
        yield return new WaitForSeconds(clearButtonPressDelay);

        // Timer has elapsed
        clearButton.interactable = true;
        backButton.interactable = true;

        canClearScores = true;
        canGoBack = true;

    }
}
