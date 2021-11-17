using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SplashSequence : MonoBehaviour
{
    public static int SceneNum = 1;

    void Start()
    {
        if (SceneNum == 1)
        {
            StartCoroutine(ToSplashTwo());
        }
        if (SceneNum == 2)
        {
            StartCoroutine(ToSplashThree());
        }
        if (SceneNum == 3)
        {
            StartCoroutine(ToMainMenu());
        }
    }

    IEnumerator ToSplashTwo()
    {
        yield return new WaitForSeconds(2);
        SceneNum = 2;
        SceneManager.LoadScene(2);
    }

    IEnumerator ToSplashThree()
    {
        yield return new WaitForSeconds(2);
        SceneNum = 3;
        SceneManager.LoadScene(3);
    }

    IEnumerator ToMainMenu()
    {
        yield return new WaitForSeconds(2);
        SceneNum = 4;
        SceneManager.LoadScene(4);
    }

}
