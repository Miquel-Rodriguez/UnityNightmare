using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundRockDestroy : MonoBehaviour
{
    private AudioSource audioSorce;
    [SerializeField]
    private AudioClip [] clips;
    void Start()
    {
        audioSorce = GetComponent<AudioSource>();
    }

    public void SoundkDestroy()
    {
        audioSorce.clip = clips[Random.Range(0, 3)];
        audioSorce.Play();
    }
}
