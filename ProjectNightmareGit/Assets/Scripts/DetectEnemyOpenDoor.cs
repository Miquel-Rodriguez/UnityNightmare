using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectEnemyOpenDoor : MonoBehaviour
{
    [SerializeField]
    private GameObject[] portes;

    private Animator animaciones;


    private float numEnemies=0;
    private float numBaloons=0;

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
                print("abriendo");
                child.GetComponent<BoxCollider2D>().enabled = false;
                animaciones = child.GetComponent<Animator>();
                animaciones.SetBool("open", true);
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

    private void Start()
    {
    }

    public void Mirar()
    {
        print(NumBaloons + "      baloons");
        
    }





}
