using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TicketSound : MonoBehaviour
{
    private AudioSource audioSorce;

    public void SoundTicket()
    {
       GetComponent<AudioSource>().Play();
    }
}
