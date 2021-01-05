using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public int Id;
    public string type;
    public string descripcion;
    public Sprite icon;

    [HideInInspector]
    public bool pickUp;
}
