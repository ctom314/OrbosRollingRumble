using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GuiButtonHandler : MonoBehaviour
{
    private GameManager gm;

    // Start is called before the first frame update
    void Start()
    {
        // Only works when script is attached to the same object
        gm = GetComponent<GameManager>();
    }

    public void loadGame()
    {
        // Load the game
        SceneManager.LoadScene("MainLevel");
    }

    public void resumeGame()
    {
        gm.resumeGame();
    }

    public void quitGame()
    {
        // Only works in a built game
        Application.Quit();
    }

    public void displayMenu()
    {

    }
}
