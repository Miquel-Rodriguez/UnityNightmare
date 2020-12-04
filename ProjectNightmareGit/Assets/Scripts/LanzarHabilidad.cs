using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanzarHabilidad : MonoBehaviour
{

    public float speed;


    // Update is called once per frame
    void Update()
    {
        //Hacer que el objeto se meuva en una dirreción
        transform.Translate(-Vector3.up * Time.deltaTime * speed);
       
    }
}
