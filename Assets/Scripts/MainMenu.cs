using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public void QuitGame()
    {
        // Quit the game
        Application.Quit();
    }

    // Go to main menu
    public void GoToMainMenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }

    // Go to How to Play
    public void GoToHowToPlay()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(4);
    }
}
