using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Clase que sirve para ir cambiando el sortinglayer según la posición en y del objeto
public class FixDepth : MonoBehaviour
{
  
    public bool fixEveryFrame;
    SpriteRenderer spr;
    void Start()
    {
        spr = GetComponent<SpriteRenderer>();
        spr.sortingLayerName = "ruinas";
        spr.sortingOrder = Mathf.RoundToInt(-transform.position.y * 100);
    }

    void Update()
    {
        if (fixEveryFrame)
        {
            spr.sortingOrder = Mathf.RoundToInt(-transform.position.y * 100);
        }
    }
}
