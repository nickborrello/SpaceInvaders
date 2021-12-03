using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayLevelOne()
    {
        StartCoroutine(playLevelOne());
    }

    public void PlayLevelTwo()
    {
        StartCoroutine(playLevelTwo());
    }

    public void PlayOriginalGame()
    {
        StartCoroutine(playOriginalGame());
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    IEnumerator playLevelOne()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("Level 1");
    }

    IEnumerator playLevelTwo()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("Level 2");
    }

    IEnumerator playOriginalGame()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("Original");
    }

}
