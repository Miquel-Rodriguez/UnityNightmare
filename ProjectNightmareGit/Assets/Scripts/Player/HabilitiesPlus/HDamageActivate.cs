using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HDamageActivate : MonoBehaviour
{
    [SerializeField]
    private float newDamage;


    public void AddDamage()
    {
        if (FindObjectOfType<MovimientoPlyaer>().Tickets >= 10)
        { 
            FindObjectOfType<MovimientoPlyaer>().damageV = newDamage;
            FindObjectOfType<MovimientoPlyaer>().Tickets -= 10;
            FindObjectOfType<MovimientoPlyaer>().UploadTickets();
            DisableButton();
        }
           
    }

    public void DisableButton()
    {
        GetComponent<Button>().interactable = false;
    }
}
