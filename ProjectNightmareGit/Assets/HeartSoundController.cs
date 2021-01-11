using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartSoundController : MonoBehaviour
{
    public void HeartSoundUp()
    {
        GameObject.Find("Boss").GetComponent<AudioSource>().volume = 1;
    }
}
