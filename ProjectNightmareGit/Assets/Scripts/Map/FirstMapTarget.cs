using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstMapTarget : MonoBehaviour
{

    [SerializeField]
    private GameObject Targetmap;
    [SerializeField]
    private GameObject camera;
    void Awake()
    {
        camera.GetComponent<MainCamera>().SetBounds(Targetmap);
    }

}
