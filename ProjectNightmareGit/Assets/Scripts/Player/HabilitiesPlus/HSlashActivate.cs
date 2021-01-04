using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HSlashActivate : MonoBehaviour
{

    public void AddSlash()
    {
        if (FindObjectOfType<MovimientoPlyaer>().Tickets >= 10)
        {
            FindObjectOfType<MovimientoPlyaer>().Tickets -= 10;
            FindObjectOfType<MovimientoPlyaer>().haveSlash = true;
            FindObjectOfType<MovimientoPlyaer>().UploadTickets();
            DisableButton();
        }

    }
    public void DisableButton()
    {
        GetComponent<Button>().interactable = false;
    }
}
