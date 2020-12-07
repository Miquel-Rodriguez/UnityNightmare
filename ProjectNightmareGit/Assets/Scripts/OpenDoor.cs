using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    public GameObject objectToDisable;


    private void Update()
    {
        print("close");
        objectToDisable.GetComponent<BoxCollider2D>().enabled = false;
    }


}