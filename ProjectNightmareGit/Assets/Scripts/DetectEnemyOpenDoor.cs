using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectEnemyOpenDoor : MonoBehaviour
{
    public GameObject[] portes;


    private static bool puedeDesbloquear=false;
    public bool PuedeDesbloquear 
    {
        set { puedeDesbloquear = value; }
    }
    private void OnTriggerStay2D(Collider2D collision)  
    {
        if (collision.transform.CompareTag("Enemy"))
        {
            puedeDesbloquear = false;
            foreach (GameObject porta in portes)
            {
                porta.GetComponent<BoxCollider2D>().enabled = true;
            }
        }
        if (collision.transform.CompareTag("Player") && puedeDesbloquear)
        {
            foreach (GameObject porta in portes)
            {
                porta.GetComponent<BoxCollider2D>().enabled = false;
            }
        }
    }





}
