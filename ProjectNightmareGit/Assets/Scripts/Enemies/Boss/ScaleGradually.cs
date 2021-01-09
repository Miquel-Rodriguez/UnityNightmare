using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleGradually : MonoBehaviour
{
    private float x;
    private float y;
    void Start()
    {
       
    }

  
    void Update()
    {
        if (x <= 0.3)
        {
          x += 1f * Time.deltaTime;
          y += 1f * Time.deltaTime;
          transform.localScale = new Vector2(x, y);
        }
    }

    public void VolverNormalidad()
    {
        x = 0.01f;
        y = 0.01f;
        transform.localScale = new Vector2(x, y);
    }
}
