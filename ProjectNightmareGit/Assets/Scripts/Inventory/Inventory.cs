using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{

    private bool inventoryEnabled;
    [SerializeField]
    private GameObject inventory;

    private int allSlots;

    private int enabledSlots;

    private GameObject[] slot;

    [SerializeField]
    private GameObject slotHolder;

    private int ticketPosition=-1;
    private int potionPosition = -1;
    private int key1position;
    private int key2Position;

    void Start()
    {
        allSlots = slotHolder.transform.childCount;

        slot = new GameObject[allSlots];

        for (int i = 0; i < allSlots; i++)
        {
            slot[i] = slotHolder.transform.GetChild(i).gameObject;
           
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            inventoryEnabled = !inventoryEnabled;
        }

        if (inventoryEnabled)
        {
            inventory.SetActive(true);
        }
        else inventory.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Item"))
        {
            GameObject itemPickedUp = collision.gameObject;

            Item item = itemPickedUp.GetComponent<Item>();

            AddItem(itemPickedUp, item.Id, item.type, item.descripcion, item.icon);
        }
    }

    private void AddItem(GameObject itemObject, int itemId, string itemType, string itemDescription, Sprite itemIcon)
    {
        for (int i = 0; i < allSlots; i++)
        {
           
            if (slot[i].GetComponent<Slot>().Empty)
            {
                slot[i].GetComponent<Slot>().item = itemObject;
                
                slot[i].GetComponent<Slot>().Id = itemId;
                slot[i].GetComponent<Slot>().type = itemType;
                slot[i].GetComponent<Slot>().descripcion = itemDescription;
                slot[i].GetComponent<Slot>().icon = itemIcon;

               // itemObject.transform.parent = slot[i].transform;
                

                
                

                if (itemId == 1 && ticketPosition==-1)//tickets
                {
                    ticketPosition = i;
                    FindObjectOfType<MovimientoPlyaer>().PlusTicket();

                }else if (itemId == 3 && potionPosition == -1)
                {
                    potionPosition = i;
                }else if (itemId == 0)
                {
                    key1position = i;
                }else if (itemId == 3)
                {
                    key2Position = i;
                }
                if (itemType == "Key")
                {
                    FindObjectOfType<MovimientoPlyaer>().putKey(itemObject.GetComponent<GetKey>().NumKey);
                }

                if(itemId == 4)//potis
                {

                    return;
                }


                slot[i].GetComponent<Slot>().UpdateSlot();
                slot[i].GetComponent<Slot>().Empty = false;
                Destroy(itemObject);
                return;
            }
            else if(slot[i].GetComponent<Slot>().Id == itemId)
            {
                
                slot[i].GetComponent<Slot>().NumItems += 1;
                slot[i].GetComponent<Slot>().UpdateNumItems();

                if (itemId == 1)
                {
                    FindObjectOfType<MovimientoPlyaer>().PlusTicket();
                }
                    
                 Destroy(itemObject);
                
                return;
            }

            
        }
    }

    public void InventoriLessTickets()
    {
        slot[ticketPosition].GetComponent<Slot>().NumItems = FindObjectOfType<MovimientoPlyaer>().Tickets;
        slot[ticketPosition].GetComponent<Slot>().UpdateNumItems();
    }

    public void InventoryLessPotion()
    {
        slot[potionPosition].GetComponent<Slot>().NumItems -= 1;
        slot[potionPosition].GetComponent<Slot>().UpdateNumItems();
    }

    public void InventoryLessKeyLvl1()
    {

        slot[key2Position].GetComponent<Slot>().NumItems -= 1;
        slot[key2Position].GetComponent<Slot>().UpdateNumItems();
    }

}
