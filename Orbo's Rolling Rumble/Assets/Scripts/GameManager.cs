using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private bool isPaused = false;

    public PlayerController playerController;
    public int clockPowerupCount;
    public int maxPowerupCount;

    // UI: Pause Menu
    public GameObject pauseMenu;
    public GameObject pauseTip;
    public GameObject pauseDarkenBackground;

    // UI: Powerup stuff
    public TextMeshProUGUI powerupCountText;
    public TextMeshProUGUI powerupCountShadow;
    public GameObject timeSlowUI;
    public Image powerupHint;
    public Slider timeLeftSlider;

    // Timer vars
    public int powerupDuration;
    public float slowTimeScale;
    private float time;
    private bool timeSlowed = false;
    private float prevTimeScale;

    // Pause menu time vars to ensure pressing Q does not pause and quit game at the same time
    private float pausePressTime = 0f;
    private float quitDelay = 0.05f;

    // Update is called once per frame
    void Update()
    {
        // Buttons
        powerupButtonPress();

        if (playerController.isAlive)
        {
            pauseMenuButtons();
        }

        // If powerup is active, slow time
        if (timeSlowed && !isPaused)
        {
            slowTime();
        }

        // If player has at least one powerup, show hint
        if (clockPowerupCount > 0)
        {
            powerupHint.gameObject.SetActive(true);
        }
        else
        {
            powerupHint.gameObject.SetActive(false);
        }
    }

    public void pauseMenuButtons()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (!isPaused)
            {
                // Pause game
                pauseGame();
                isPaused = true;
                pausePressTime = Time.unscaledTime;
            }

            // Quit game after delay
            else if (isPaused && (Time.unscaledTime - pausePressTime) > quitDelay)
            {
                Time.timeScale = 1;
                SceneManager.LoadScene("MainMenu");
            }
        }

        if (isPaused && Input.GetKeyDown(KeyCode.Space))
        {
            // Resume game
            resumeGame();
            isPaused = false;
        }
    }

    private void powerupButtonPress()
    {
        // Activate under certain conditions
        if (playerController.isAlive &&
            clockPowerupCount > 0 &&
            !timeSlowed &&
            !isPaused &&
            Input.GetKeyDown(KeyCode.F))
        {
            // Use powerup if player has one
            clockPowerupCount -= 1;
            updatePowerupCount();

            // Slow time
            Time.timeScale = slowTimeScale;
            timeSlowed = true;
        }
    }

    private void slowTime()
    {
        // Show time slow text
        timeSlowUI.gameObject.SetActive(true);

        // Increment timer, ignore time scale
        time += Time.unscaledDeltaTime;

        // Update slider
        timeLeftSlider.value = powerupDuration - time;

        // If timer is up, cancel slow time
        if (time >= powerupDuration)
        {
            cancelSlowTime();
        }
    }

    public void cancelSlowTime()
    {
        Time.timeScale = 1;
        time = 0;
        timeSlowed = false;

        // Hide time slow text
        timeSlowUI.gameObject.SetActive(false);

        // Reset slider
        timeLeftSlider.value = powerupDuration;
    }

    public void pauseGame()
    {
        // Save current time scale
        prevTimeScale = Time.timeScale;

        // Pause game
        Time.timeScale = 0;
        showPauseMenu();
    }

    public void resumeGame()
    {
        // Restore previous time scale
        Time.timeScale = prevTimeScale;

        // Resume game
        hidePauseMenu();

        // Reset jump delay
        playerController.timeSinceResume = 0;
    }

    public void showPauseMenu()
    {
        pauseMenu.SetActive(true);

        // Hide the tip
        pauseTip.SetActive(false);

        // Darken the background
        pauseDarkenBackground.gameObject.SetActive(true);
    }

    public void hidePauseMenu()
    {
        pauseMenu.SetActive(false);

        // Show the tip
        pauseTip.SetActive(true);

        // Lighten the background
        pauseDarkenBackground.gameObject.SetActive(false);
    }

    public void incClockPowerup()
    {
        clockPowerupCount += 1;
        updatePowerupCount();
    }

    private void updatePowerupCount()
    {
        powerupCountText.text = clockPowerupCount.ToString() + "/" + maxPowerupCount.ToString();
        powerupCountShadow.text = clockPowerupCount.ToString() + "/" + maxPowerupCount.ToString();
    }
}
