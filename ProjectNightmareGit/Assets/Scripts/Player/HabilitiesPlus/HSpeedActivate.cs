using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HSpeedActivate : MonoBehaviour
{
    [SerializeField]
    private float newSpeed;


    public void AddSpeed()
    {
        if (FindObjectOfType<MovimientoPlyaer>().Tickets >= 10)
        {
            FindObjectOfType<MovimientoPlyaer>().speedV = newSpeed;
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
