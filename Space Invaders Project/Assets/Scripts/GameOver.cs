using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    // Start is called before the first frame update
    public void PlayGameCurrent()
    {
        SceneManager.LoadScene("Current Build");
    }

    public void PlayGameOriginal()
    {
        SceneManager.LoadScene("Original Build");
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
