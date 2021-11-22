using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sounds : MonoBehaviour
{
    public static AudioSource boom;
    public static AudioSource pew;

    public static void playBoom()
    {
        boom.Play();
    }

    public static void playPew()
    {
        pew.Play();
    }
}
