using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetLimitsParent : MonoBehaviour
{
   
    void Start()
    {
        transform.SetParent(GameObject.Find("LimitsPack").transform);
    }

}
