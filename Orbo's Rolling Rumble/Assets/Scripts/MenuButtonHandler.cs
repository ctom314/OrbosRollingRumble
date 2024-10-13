using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtonHandler : MonoBehaviour
{
    private MenuManager mm;
    private HighscoresManager hm;

    // Start is called before the first frame update
    void Start()
    {
        mm = GetComponent<MenuManager>();
        hm = GetComponent<HighscoresManager>();
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

    // Main menu options
    public void returnToMainMenu()
    {
        mm.mainMenuActive = true;
        mm.tipsMenuActive = false;

        // Reset Highscore clear logic
        hm.warning.SetActive(false);
        hm.scoreClearButtonPresses = 0;
        hm.clearButton.interactable = true;

        // Reset Guide Menu
        mm.collectiblesInfo.SetActive(true);
        mm.tipsInfo.SetActive(false);

        // Hide all menus if active
        mm.highScoresMenu.SetActive(false);
        mm.guideMenu.SetActive(false);

        // Show main menu
        mm.mainMenu.SetActive(true);
    }

    public void loadHighScoresMenu()
    {
        mm.mainMenuActive = false;

        // Hide main menu
        mm.mainMenu.SetActive(false);

        // Show high scores menu
        mm.highScoresMenu.SetActive(true);
    }

    // Info & Tips Menu
    public void loadTipsMenu()
    {
        mm.mainMenuActive = false;
        mm.tipsMenuActive = true;

        // Hide main menu
        mm.mainMenu.SetActive(false);

        // Show tips menu, default to collectibles page
        mm.guideMenu.SetActive(true);
    }

    public void showCollectiblesPage()
    {
        mm.mainMenuActive = false;
        mm.tipsMenuActive = true;

        // Hide tips page
        mm.tipsInfo.SetActive(false);

        // Show collectibles page
        mm.collectiblesInfo.SetActive(true);
    }

    public void showTipsPage()
    {
        mm.mainMenuActive = false;
        mm.tipsMenuActive = true;

        // Hide collectibles page
        mm.collectiblesInfo.SetActive(false);

        // Show tips page
        mm.tipsInfo.SetActive(true);
    }

    public void clearHighscores()
    {
        hm.clearHighscores();
    }
}
