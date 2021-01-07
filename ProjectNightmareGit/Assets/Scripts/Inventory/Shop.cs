using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    private bool shopEnabled;
    [SerializeField]
    private GameObject shop;


    private void Start()
    {
        shop.SetActive(false);
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("BoxPlayer") || collision.CompareTag("Player"))
        {
            if (Input.GetKeyDown(KeyCode.P))
            {
                 shopEnabled = !shopEnabled;
                if (shopEnabled)
                {
                    shop.SetActive(true);
                }
                else shop.SetActive(false);
            }

            
        }
         
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        shop.SetActive(false);
    }



}
