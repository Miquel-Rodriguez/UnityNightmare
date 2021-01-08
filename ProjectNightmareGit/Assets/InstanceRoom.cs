using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstanceRoom : MonoBehaviour
{
    [SerializeField]
    private GameObject room;

    private void Start()
    {

        GameObject y = Instantiate(room, new Vector3(transform.position.x + 1.5f, transform.position.y + 1.5f), Quaternion.identity);
        y.transform.SetParent(transform);


    }
    public void InstanciarRooms()
    {


        Destroy(transform.GetChild(0).gameObject);
        GameObject y = Instantiate(room, new Vector3(transform.position.x + 1.5f, transform.position.y + 1.5f), Quaternion.identity);
        y.transform.SetParent(transform);

    }
}
