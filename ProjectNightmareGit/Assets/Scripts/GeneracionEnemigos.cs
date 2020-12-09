using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneracionEnemigos : MonoBehaviour
{

    private Transform transformP; 
    public GameObject[] enemigos;
    private void Start()
    {
        GameObject toInstantiate = enemigos[0];
        int repeats = Random.Range(2,3);
        transformP = transform.GetComponentInParent<Transform>();
        for (int i = 0; i < repeats; i++)
        {
            GameObject instance = Instantiate(toInstantiate, new Vector3(transformP.position.x+Random.Range(3, 14), transformP.position.y+ Random.Range(3, 6), 0f), Quaternion.identity);
            
        }
    }
    

    


}
