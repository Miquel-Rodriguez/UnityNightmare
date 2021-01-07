using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnClickItem : MonoBehaviour
{
    public void OnClickItems()
    {
       
        if (GetComponentInChildren<Slot>().Id == 3)
        {
            if (FindObjectOfType<Lesslife>().Life <= 11)
            {
                FindObjectOfType<Lesslife>().HealOne();
                 FindObjectOfType<Inventory>().InventoryLessPotion();
            }           
        }
    }
}
