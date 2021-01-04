using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    private bool shopEnabled;
    [SerializeField]
    private GameObject shop;

    void Update()
    {
       
            if (Input.GetKeyDown(KeyCode.P))
            {
                shopEnabled = !shopEnabled;
            }

            if (shopEnabled)
            {
                shop.SetActive(true);
            }
            else shop.SetActive(false);
        
    }
}
