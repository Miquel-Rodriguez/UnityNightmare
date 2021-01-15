using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPickUpSound : MonoBehaviour
{
    public void KeySound()
    {
        GetComponent<AudioSource>().Play();
    }
}
