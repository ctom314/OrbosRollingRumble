using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private bool isPaused = false;
    public GameObject pauseMenu;
    public GameObject pauseMenuTip;
    public TextMeshProUGUI powerupCountText;
    public GameObject timeSlowText;
    public int clockPowerupCount;

    // Timer vars
    public int powerupDuration;
    public float slowTimeScale;
    private float time;
    private bool timeSlowed = false;
    private float prevTimeScale;

    // Update is called once per frame
    void Update()
    {
        pauseButtonPress();
        powerupButtonPress();

        // DEBUGGING PURPOSES
        givePowerup();

        // If powerup is active, slow time
        if (timeSlowed && !isPaused)
        {
            slowTime();
        }
    }

    public void pauseButtonPress()
    {
        // if P is pressed, pause or resume the game
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (isPaused)
            {
                resumeGame();
                isPaused = false;
            }
            else
            {
                pauseGame();
                isPaused = true;
            }
        }
    }

    private void powerupButtonPress()
    {
        // Activate when not already have a powerup active
        if (clockPowerupCount > 0 && !timeSlowed && Input.GetKeyDown(KeyCode.F))
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
        timeSlowText.gameObject.SetActive(true);

        // Increment timer, ignore time scale
        time += Time.unscaledDeltaTime;

        // If timer is up, reset time scale
        if (time >= powerupDuration)
        {
            Time.timeScale = 1;
            time = 0;
            timeSlowed = false;

            // Hide time slow text
            timeSlowText.gameObject.SetActive(false);
        }
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
    }

    public void showPauseMenu()
    {
        pauseMenu.SetActive(true);

        // Hide the tip
        pauseMenuTip.SetActive(false);
    }

    public void hidePauseMenu()
    {
        pauseMenu.SetActive(false);

        // Show the tip
        pauseMenuTip.SetActive(true);
    }
    
    public void incClockPowerup()
    {
        clockPowerupCount += 1;
        updatePowerupCount();
    }

    private void updatePowerupCount()
    {
        powerupCountText.text = clockPowerupCount.ToString();
    }


    // DEBUGGING PURPOSES
    private void givePowerup()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            clockPowerupCount = 99;
            updatePowerupCount();
        }
    }
}
