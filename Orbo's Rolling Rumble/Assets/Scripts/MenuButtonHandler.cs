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

    // Main menu options
    public void returnToMainMenu()
    {
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
        // Hide main menu
        mm.mainMenu.SetActive(false);

        // Show high scores menu
        mm.highScoresMenu.SetActive(true);
    }

    // Info & Tips Menu
    public void loadTipsMenu()
    {
        // Hide main menu
        mm.mainMenu.SetActive(false);

        // Show tips menu, collectibles info
        mm.guideMenu.SetActive(true);
    }

    public void showCollectiblesInfo()
    {
        // Hide tips info
        mm.tipsInfo.SetActive(false);

        // Show collectibles info
        mm.collectiblesInfo.SetActive(true);
    }

    public void showTipsInfo()
    {
        // Hide collectibles info
        mm.collectiblesInfo.SetActive(false);

        // Show tips info
        mm.tipsInfo.SetActive(true);
    }
}
