using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectEnemyOpenDoor : MonoBehaviour
{

    private Animator animaciones;

    [SerializeField]
    private float numEnemies;
    [SerializeField]
    private float numBaloons;

    private float variable;

    public float NumEnemies { set { numEnemies = value; } get { return numEnemies;} }
    public float NumBaloons { set { numBaloons = value; } get { return numBaloons; } }

    public float Variable { set { variable = value; } get { return variable; } }
    public void ComprobarEnemigos()
    {
        if (NumBaloons == 0 && NumEnemies==variable*2)
        {
            foreach (Transform child in gameObject.GetComponent<Transform>())
            {
                if (child.CompareTag("Door"))
                {
                child.GetComponent<BoxCollider2D>().enabled = false;
                animaciones = child.GetComponent<Animator>();
                animaciones.SetBool("open", true);

                    if(transform.CompareTag("check1"))
                    {
                        FindObjectOfType<RoomControl>().l1 = false;
                    }else if (transform.CompareTag("check2"))
                    {
                        FindObjectOfType<RoomControl>().l2 = false;
                    }else if (transform.CompareTag("check3"))
                    {
                        FindObjectOfType<RoomControl>().l3 = false;
                    }
                }
                if (child.CompareTag("DoorKey"))
                {
                    child.GetComponent<BoxCollider2D>().enabled = false;
                    child.GetChild(0).gameObject.SetActive(true);
                }
                
                if (child.CompareTag("MultiStone"))
                {
                    child.GetComponent<EStatic4>().Atacando = false;
                }
            }   
        }
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            NumEnemies++;
            ComprobarEnemigos();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("explosion"))
        {
            NumBaloons--;
            ComprobarEnemigos();    
        }
    }
}
