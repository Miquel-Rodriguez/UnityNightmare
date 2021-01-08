using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCamera : MonoBehaviour
{
    [SerializeField]
    private string toEnable;
    [SerializeField]
    private string toDisable;

    private GameObject cam1;
    private GameObject cam2;

    private void Start()
    {
        cam1 = GameObject.Find(toEnable);
        cam2 = GameObject.Find(toDisable);
    }
    public void ChangeCameras()
    {
        cam1.SetActive(true);
        cam2.SetActive(false);
        
    }

    public void ActivateAllCameras()
    {
        cam1.SetActive(true);
        cam2.SetActive(true);
    }

}
