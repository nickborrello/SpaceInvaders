using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        StartCoroutine(playGame());
    }

    public void PlayOriginalGame()
    {
        StartCoroutine(playOriginalGame());
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    IEnumerator playGame()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(5);
    }

    IEnumerator playOriginalGame()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(6);
    }
}
