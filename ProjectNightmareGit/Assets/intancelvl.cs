using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class intancelvl : MonoBehaviour
{
    [SerializeField]
    private GameObject lvl;
   
    void Start()
    {
        GameObject lvll = Instantiate(lvl, transform.position, Quaternion.identity);
        lvll.transform.SetParent(transform);
    }


    public void InstanciarNivel1()
    {
        GameObject lvll = Instantiate(lvl, transform.position, Quaternion.identity);
        lvll.transform.SetParent(transform);
        Destroy(transform.GetChild(0).gameObject);
    }
}
