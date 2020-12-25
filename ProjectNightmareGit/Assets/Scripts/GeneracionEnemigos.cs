using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneracionEnemigos : MonoBehaviour
{

    private Transform transformP;
    [SerializeField]
    private GameObject[] enemigos;
    [SerializeField]
    private int maxEenemies;
    [SerializeField]
    private int minEnemies;



    private DetectEnemyOpenDoor d;
    private void Start()
    {

        int repeats = Random.Range(minEnemies, maxEenemies);
        transformP = transform.GetComponentInParent<Transform>();
        d = GetComponent<DetectEnemyOpenDoor>();
        for (int i = 0; i < repeats; i++)
        {
            // GameObject toInstantiate = enemigos[Random.Range(0, enemigos.Length)] as GameObject;
            //  toInstantiate.transform.parent= transform;
            //  Instantiate(toInstantiate, new Vector3(transformP.position.x+Random.Range(3, 13), transformP.position.y+ Random.Range(3, 7), 0f), Quaternion.identity) ;

            GameObject myEnemy = enemigos[Random.Range(0, enemigos.Length)] as GameObject;
            myEnemy = Instantiate(myEnemy , new  Vector3(transformP.position.x + Random.Range(3, 13), transformP.position.y + Random.Range(3, 7), 0f), Quaternion.identity) as GameObject;
            myEnemy.transform.parent = transform;


            if (myEnemy.transform.CompareTag("Enemy"))
            {
                 d.NumEnemies-=2;
                
                print(d.NumEnemies);
            }
            else if (myEnemy.transform.CompareTag("explosion"))
            {
                d.NumBaloons++;
                print(d.NumBaloons);
            }
            
           
        }

       

    }
    

    


}
