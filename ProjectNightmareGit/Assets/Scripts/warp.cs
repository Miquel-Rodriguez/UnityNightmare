using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class warp : MonoBehaviour
{

    public GameObject target;
    public GameObject Targetmap;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            // desplazar a other (player) a la posición target del
            other.transform.position = target.transform.GetChild(0).transform.position;
            Camera.main.GetComponent<MainCamera>().SetBounds(Targetmap);

        }
    }




}
