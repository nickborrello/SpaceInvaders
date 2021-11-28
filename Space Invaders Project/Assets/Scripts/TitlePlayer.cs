using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitlePlayer : MonoBehaviour
{
    public AudioSource startSound;

    public void Update()
    {
        if(Input.anyKey)
        {
            StartCoroutine(titleTransition());
        }
    }

    IEnumerator titleTransition()
    {
        startSound.Play();
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("Unity");
    }
}
