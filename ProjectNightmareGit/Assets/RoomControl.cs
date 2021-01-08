using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomControl : MonoBehaviour
{
    [SerializeField]
    private GameObject[] roomsL1;
    [SerializeField]
    private GameObject[] roomsL2;
    [SerializeField]
    private GameObject[] roomsL3;

    public bool l1 { get; set; }
    public bool l2 { get; set; }
    public bool l3 { get; set; }

    private void Start()
    {
        l1 = true;
        l2 = true;
        l3 = true;
    }
    public void RoomsControl()
    {
        if (l1)
        {
            print(l1 + " room");
            FindObjectOfType<intancelvl>().InstanciarNivel1();
            FindObjectOfType<MovimientoPlyaer>().PutKeysInFalse(1,2);
            FindObjectOfType<Inventory>().InventoryLessKeyLvl1();
            StartCoroutine(FindObjectOfType <FirstBoundingShape>().GetNewComposite());
        }
        if (l2)
        {
            FindObjectOfType<Shop>().ActiveAfterDie();
            FindObjectOfType<intancelvl>().InstanciarNivel2();
            FindObjectOfType<MovimientoPlyaer>().PutKeysInFalse(3,3);
            FindObjectOfType<Inventory>().InventoryLessKeyLvl1();
        }
        if (l3 && roomsL3 != null)
        {
            foreach (GameObject room in roomsL3)
            {
                room.GetComponent<InstanceRoom>().InstanciarRooms();
            }
        }
        FindObjectOfType<Lesslife>().RestoreLife();
    }
}
