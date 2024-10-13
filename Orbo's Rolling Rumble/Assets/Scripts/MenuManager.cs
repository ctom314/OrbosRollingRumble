using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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

    // Menu Bools
    public bool mainMenuActive = true;
    public bool tipsMenuActive = false;

    private MenuButtonHandler mbh;
    private HighscoresManager hm;

    // Timer vars for pressing Q to return to main menu, while preventing quitting at the same time
    private float menuChangeTime = 0f;
    private float quitDelay = 0.05f;

    // Start is called before the first frame update
    void Start()
    {
        mbh = GetComponent<MenuButtonHandler>();
        hm = GetComponent<HighscoresManager>();
    }

    // Update is called once per frame
    void Update()
    {
        // Menu Buttons
        if (mainMenuActive && !tipsMenuActive)
        {
            // Main menu buttons
            startGame();
            quitGame();
            highScoresMenuButton();
            tipsMenuButton();
        }
        else if (!mainMenuActive && tipsMenuActive)
        {
            // Toggle info menu pages
            toggleInfoPages();
            backToMainMenu();
        }
        else if (!mainMenuActive && !tipsMenuActive)
        {
            backToMainMenu();
        }
    }

    private void startGame()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("MainLevel");
            Time.timeScale = 1;
        }
    }

    private void quitGame()
    {
        // Ensure quitting is not possible immediately after returning to main menu
        if (Input.GetKeyDown(KeyCode.Q) && (Time.unscaledTime - menuChangeTime) > quitDelay)
        {
            mbh.quitGame();
        }
    }

    private void highScoresMenuButton()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            mbh.loadHighScoresMenu();
        }
    }

    private void tipsMenuButton()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            tipsMenuActive = true;

            mbh.loadTipsMenu();
        }
    }

    private void toggleInfoPages()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (collectiblesInfo.activeSelf)
            {
                mbh.showTipsPage();
            }
            else
            {
                mbh.showCollectiblesPage();
            }
        }
    }

    private void backToMainMenu()
    {
        if (hm.canGoBack && Input.GetKeyDown(KeyCode.Q))
        {
            mbh.returnToMainMenu();
            menuChangeTime = Time.unscaledTime;
        }
    }
}
