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
        gm = GetComponent<GameManager>();
    }

    public void resumeGame()
    {
        gm.resumeGame();
    }

    public void returnToMainMenu()
    {
        // Load main menu
        SceneManager.LoadScene("MainMenu");
    }

    public void playAgain()
    {
        // Load game
        SceneManager.LoadScene("MainLevel");
    }
}
