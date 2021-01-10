using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    private float newVolume;
    [SerializeField]
    private float MaxVolum;

    private void Start()
    {
        GetComponent<AudioSource>().Play();
        GetComponent<AudioSource>().volume = 0;
        FadeIn();
    }
    private void Update()
    {
        ControlVolum();
    }

    private bool start = false;
    private bool isFadeIn = false;

    private void ControlVolum()
    {
        if (!start)
            return;
        if (isFadeIn)
        {
            newVolume = Mathf.Lerp(newVolume, MaxVolum+ 0.1f, MaxVolum * Time.deltaTime);
            if (newVolume > MaxVolum) start = false;
        }
        else
        {
            newVolume = Mathf.Lerp(newVolume, -0.1f, 1 * Time.deltaTime);
            if (newVolume < 0.01) start = false;
        }
        GetComponent<AudioSource>().volume = newVolume;
    }

    public void FadeIn()
    {
        start = true;
        isFadeIn = true;
    }

    public void FadeOut()
    {
        isFadeIn = false;
        start = true;
    }

}
