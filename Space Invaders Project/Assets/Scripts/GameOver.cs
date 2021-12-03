using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{

    public GameObject gameOverUI;
    public int level;

    // Update is called once per frame

    public void Retry()
    {
        if (level == 0)
        {
            SceneManager.LoadScene("Original");
        }
        if (level == 1)
        {
            SceneManager.LoadScene("Level 1");
        }
        if (level == 2)
        {
            SceneManager.LoadScene("Level 2");
        }
    }

    public void returnMenu()
    {
        SceneManager.LoadScene("Main Menu");
        Time.timeScale = 1f;
        level = 0;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
