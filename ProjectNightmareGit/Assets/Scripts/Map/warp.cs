using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class warp : MonoBehaviour
{
    [SerializeField]
    private GameObject target;
    [SerializeField]
    private GameObject Targetmap;
    [SerializeField]
    private GameObject camera;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // desplazar a other (player) a la posición target del
            other.transform.position = target.transform.GetChild(0).transform.position;
            if(Targetmap != null){
                camera.GetComponent<MainCamera>().SetBounds(Targetmap);
            }
            else
            {
                gameObject.GetComponent<ChangeCamera>().ChangeCameras();
            }
            

        }
    }




}
