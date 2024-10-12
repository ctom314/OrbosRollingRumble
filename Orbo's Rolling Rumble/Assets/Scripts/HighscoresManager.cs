using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class HighscoresManager : MonoBehaviour
{
    public TextMeshProUGUI[] highscoreTexts;

    // Start is called before the first frame update
    void Start()
    {
        // Update highscores
        updateHighscores();
    }

    private void updateHighscores()
    {
        // Update each TextMeshProUGUI element with the corresponding highscore
        for (int i = 0; i < highscoreTexts.Length; i++)
        {
            // Default highscore is 0
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
}
