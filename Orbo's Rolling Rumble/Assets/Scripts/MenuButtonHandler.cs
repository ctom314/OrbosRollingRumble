using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtonHandler : MonoBehaviour
{
    private MenuManager mm;
    
    // Start is called before the first frame update
    void Start()
    {
        // Get MenuManager
        mm = GetComponent<MenuManager>();
    }

    public void quitGame()
    {
        // Only works in a built game
        Application.Quit();
    }

    public void loadGame()
    {
        SceneManager.LoadScene("MainLevel");
        Time.timeScale = 1;
    }

    public void returnToMainMenu()
    {
        // Hide high scores menu
        mm.highScoresMenu.SetActive(false);

        // Show main menu
        mm.mainMenu.SetActive(true);
    }

    public void loadHighScoresMenu()
    {
        // Hide main menu
        mm.mainMenu.SetActive(false);

        // Show high scores menu
        mm.highScoresMenu.SetActive(true);
    }
}
