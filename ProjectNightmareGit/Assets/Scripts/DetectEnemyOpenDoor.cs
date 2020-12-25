using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectEnemyOpenDoor : MonoBehaviour
{
    [SerializeField]
    private GameObject[] portes;

    private Animator animaciones;


    public float numEnemies = 0;
    public float numBaloons = 0;

    public float NumEnemies { set { numEnemies = value; } get { return numEnemies;} }
    public float NumBaloons { set { numBaloons = value; } get { return numBaloons; } }

    public void ComprobarEnemigos()
    {
        if (NumBaloons <= 0 && NumEnemies==0)
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
            print(NumEnemies);
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
        StartCoroutine(Mirar());
    }

    public IEnumerator Mirar()
    {
        while (true)
        {
            print(NumEnemies + "   tirdaores");
            print(NumBaloons + "baloons");
           
            
            yield return new WaitForSeconds(1);
            
        }
        
    }





}
