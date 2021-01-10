using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class FirstBoundingShape : MonoBehaviour
{
    
    void Start()
    {
        print("Limites1-1");
        StartCoroutine(GetNewComposite());
        
    }

    public IEnumerator GetNewComposite()
    {
        yield return new WaitForSeconds(1);
        gameObject.GetComponent<CinemachineConfiner>().m_BoundingShape2D = GameObject.Find("Limites1-1").GetComponent<Collider2D>();
    }

}
