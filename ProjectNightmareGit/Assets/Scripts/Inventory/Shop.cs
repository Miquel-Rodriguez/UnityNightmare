using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Shop : MonoBehaviour
{
    private bool shopEnabled;
    [SerializeField]
    private GameObject shop;
    [SerializeField]
    private string nameCanvas;
    private Canvas canvas;
    private bool activarmsg = true;

   
    private void Start()
    {
        shop = GameObject.Find("CShop");
        canvas = GameObject.Find(nameCanvas).GetComponent<Canvas>();
        shop.SetActive(false);
        
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("BoxPlayer"))
        {
            canvas.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = "Pulsa P para habrir  y cerrar la tienda";
            if (activarmsg)
            {
                canvas.enabled = true;
            }
            
            if (Input.GetKeyDown(KeyCode.P))
            {
                canvas.enabled = false;
                activarmsg = false;
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
        if (collision.CompareTag("BoxPlayer")) {
            canvas.enabled = false;
            shop.SetActive(false);
            activarmsg = true;
        }
    }


    public void ActiveAfterDie()
    {
        shop.SetActive(true);
    }
}
