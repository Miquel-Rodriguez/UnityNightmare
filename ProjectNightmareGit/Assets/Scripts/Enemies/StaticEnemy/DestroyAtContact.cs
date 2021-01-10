using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAtContact : MonoBehaviour
{
    private SoundRockDestroy sound;
    private void Start()
    {
        sound = FindObjectOfType<SoundRockDestroy>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Wall") || collision.CompareTag("BoxPlayer"))
        {
            sound.SoundkDestroy();
            Destroy(gameObject);
        }
    }
}
