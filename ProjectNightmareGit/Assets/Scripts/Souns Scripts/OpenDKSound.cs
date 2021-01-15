using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDKSound : MonoBehaviour
{
    public void playOpen()
    {
        GetComponent<AudioSource>().Play();
    }
}
