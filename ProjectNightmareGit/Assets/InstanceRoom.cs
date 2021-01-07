using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstanceRoom : MonoBehaviour
{
    private bool ins;
    private GameObject room;

    private void Start()
    {
        print(ins + " ins");
    }
    public void InstanciarRooms()
    {
        if (ins)
        {
            Destroy(transform.GetChild(0));
            GameObject toinstance = room;
            Instantiate(toinstance, transform.position, Quaternion.identity);
        }
    }
}
