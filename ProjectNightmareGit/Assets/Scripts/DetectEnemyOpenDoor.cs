using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectEnemyOpenDoor : MonoBehaviour
{
    [SerializeField]
    private GameObject[] portes;
    string ta;
    private static bool puedeDesbloquear=false;
    public bool PuedeDesbloquear 
    {
        set { puedeDesbloquear = value; }
    }
    private void OnTriggerStay2D(Collider2D collision)  
    {
        
        if (collision.transform.CompareTag("Enemy") )
        {
            print("Tenca");
            print(collision.transform.tag);
            puedeDesbloquear = false;
            foreach (GameObject porta in portes)
            {
               
                porta.GetComponent<BoxCollider2D>().enabled = true;
            }
        }
        if (collision.transform.CompareTag("Player") && puedeDesbloquear)
        {
            print("Obra");
            foreach (GameObject porta in portes)
            {
                porta.GetComponent<BoxCollider2D>().enabled = false;
            }
        }
    }





}
