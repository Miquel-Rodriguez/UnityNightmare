using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class intancelvl : MonoBehaviour
{
    [SerializeField]
    private GameObject[] lvl;
   
    void Start()
    {
        GameObject lvl1 = Instantiate(lvl[0], transform.position, Quaternion.identity);
        lvl1.transform.SetParent(transform);

        GameObject lvl2 = Instantiate(lvl[1], new Vector2(transform.position.x+142.6f, transform.position.y+ 297.5f), Quaternion.identity);
        lvl2.transform.SetParent(transform);

        GameObject lvl3 = Instantiate(lvl[2], new Vector2(transform.position.x - 83.8f, transform.position.y - 72.3f), Quaternion.identity);
        lvl3.transform.SetParent(transform);
    }


    public void InstanciarNivel1()
    {
        GameObject lvl1 = Instantiate(lvl[0], transform.position, Quaternion.identity);
        lvl1.transform.SetParent(transform);
        Destroy(transform.GetChild(0).gameObject);
    }

    public void InstanciarNivel2()
    {
        GameObject lvl2 = Instantiate(lvl[1], new Vector2(transform.position.x + 142.6f, transform.position.y + 297.5f), Quaternion.identity);
        lvl2.transform.SetParent(transform);
        Destroy(transform.GetChild(1).gameObject);
    }

    public void InstanciarNivel3()
    {
        GameObject lvl3 = Instantiate(lvl[2], new Vector2(transform.position.x - 83.8f, transform.position.y - 72.3f), Quaternion.identity);
        lvl3.transform.SetParent(transform);
        Destroy(transform.GetChild(2).gameObject);
    }
}

