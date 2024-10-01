using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    // Menu objects
    public GameObject mainMenu;
    public GameObject highScoresMenu;

    // Info & Tips
    public GameObject guideMenu;
    public GameObject collectiblesInfo;
    public GameObject tipsInfo;

    // Update is called once per frame
    void Update()
    {
        // Buttons
        startGame();
        quitGame();
    }

    private void startGame()
    {
        // Press Space to start game
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("MainLevel");
            Time.timeScale = 1;
        }
    }

    private void quitGame()
    {
        // Press Q to quit game
        if (Input.GetKeyDown(KeyCode.Q))
        {
            // Only works in a built game
            Application.Quit();
        }
    }
}
