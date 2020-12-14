using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectEnemyOpenDoor : MonoBehaviour
{
    public GameObject[] portes;




    //se puede creaer una hitbox que sdesaparezca al detectar el primer enemigo (solución guarra)
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Enemy") || collision.transform.CompareTag("RockAttack"))
        {
            foreach (GameObject porta in portes)
            {
                porta.GetComponent<BoxCollider2D>().enabled = true;
            }
        }
        else if (!collision.transform.CompareTag("Attack"))
        {
            print(collision.transform.tag);
            foreach (GameObject porta in portes)
            {
                porta.GetComponent<BoxCollider2D>().enabled = false;
            }
        }
    }
}
