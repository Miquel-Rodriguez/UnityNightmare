using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanzarHabilidad : MonoBehaviour
{
    [SerializeField]
    private float speed;

    void Update()
    {
        //Hacer que el objeto se meuva en una dirreción
        transform.Translate(-Vector3.up * Time.deltaTime * speed);
       
    }
}
