using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Slot : MonoBehaviour
{
    public GameObject item;
    public int Id;
    public string type;
    public string descripcion;
    public Sprite icon;
    
    [SerializeField]
    private bool empty = true;
    public bool Empty { get { return empty; } set { empty = value; } }
    public int NumItems { get; set; }

    private Transform slotIcon;
    private Transform slotNum;

    private void Start()
    {
        slotIcon = transform.GetChild(0);
        slotNum = transform.GetChild(1);
        NumItems = 0;
    }

    public void UpdateSlot()
    {
        slotIcon.GetComponent<Image>().sprite = icon;
        UpdateNumItems();
    }

    public void UpdateNumItems()
    {
        slotNum.GetComponent<Text>().text =  NumItems.ToString();
    }


}
