using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectEnemyOpenDoor : MonoBehaviour
{
    public GameObject[] portes;





    private void OnTriggerStay2D(Collider2D collision)
    {
        if ((collision.transform.tag == "Enemy") || (collision.transform.tag == "RockAttack"))
        {
            
            foreach (GameObject porta in portes)
            {
                porta.GetComponent<BoxCollider2D>().enabled = true;
            }
        }
        else if (!(collision.transform.tag == "Attack") || !(collision.transform.tag == "BoxPlayer")){
            print(collision.transform.tag);
            foreach (GameObject porta in portes)
            {
                porta.GetComponent<BoxCollider2D>().enabled = false;
            }
        }
    }
}
