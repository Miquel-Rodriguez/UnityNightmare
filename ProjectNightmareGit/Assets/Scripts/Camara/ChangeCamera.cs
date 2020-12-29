using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCamera : MonoBehaviour
{
    [SerializeField]
    private GameObject toEnable;
    [SerializeField]
    private GameObject toDisable;



    public void ChangeCameras()
    {
        toDisable.SetActive(false);
        toEnable.SetActive(true);
    }

}
