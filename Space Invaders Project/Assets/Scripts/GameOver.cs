using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    // Start is called before the first frame update
    public void PlayGameCurrent()
    {
        SceneManager.LoadScene(5);
    }

    public void PlayGameOriginal()
    {
        SceneManager.LoadScene(6);
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene(4);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
