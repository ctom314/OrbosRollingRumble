using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private bool isPaused = false;
    public GameObject pauseMenu;
    public GameObject pauseMenuTip;
    public GameObject player;
    // Need to add reference to Maelstrom when he is created


    // Update is called once per frame
    void Update()
    {
        pauseButtonPress();
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
                showPauseMenu();
                isPaused = true;
            }
        }
    }

    public void pauseGame()
    {
        Time.timeScale = 0;
    }

    public void resumeGame()
    {
        Time.timeScale = 1;
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
}
