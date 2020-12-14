using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TicketsUI : MonoBehaviour
{   

    public void changeTicketsText(int num)
    {
        gameObject.GetComponent<Text>().text = num.ToString();
    }
}
