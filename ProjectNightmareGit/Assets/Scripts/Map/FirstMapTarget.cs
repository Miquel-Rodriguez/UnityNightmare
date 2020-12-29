using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstMapTarget : MonoBehaviour
{

    [SerializeField]
    private GameObject Targetmap;
    void Awake()
    {
        Camera.main.GetComponent<MainCamera>().SetBounds(Targetmap);
    }

}
