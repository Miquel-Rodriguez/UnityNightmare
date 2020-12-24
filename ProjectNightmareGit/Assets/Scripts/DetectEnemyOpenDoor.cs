using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectEnemyOpenDoor : MonoBehaviour
{
    [SerializeField]
    private GameObject[] portes;
    string ta;
    private static bool puedeDesbloquear=false;

    private Animator animaciones;



    private int numEnemies;
    public int NumEnemies
    {
        set { NumEnemies = value; }
    }



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
                animaciones = porta.GetComponent<Animator>();
                animaciones.SetBool("open", false);
            }
        }

        if (collision.transform.CompareTag("Player") && puedeDesbloquear)
        {
            print("Obra");
            foreach (GameObject porta in portes)
            {
                porta.GetComponent<BoxCollider2D>().enabled = false;
                animaciones = porta.GetComponent<Animator>();
                animaciones.SetBool("open",true);
            }
        }

        if (!puedeDesbloquear)
        {
            foreach (GameObject porta in portes)
            {

                porta.GetComponent<BoxCollider2D>().enabled = true;
                animaciones = porta.GetComponent<Animator>();
                animaciones.SetBool("open", false);
            }
        }
    }

}
