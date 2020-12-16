using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    [SerializeField]
    private GameObject objectToDisable;
    private void Update()
    {
        print("close");
        objectToDisable.GetComponent<BoxCollider2D>().enabled = false;
    }


}