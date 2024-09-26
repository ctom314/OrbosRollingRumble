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
        // Load the game
        SceneManager.LoadScene("MainLevel");

        // Reset time scale if it was paused
        Time.timeScale = 1;
    }
}
