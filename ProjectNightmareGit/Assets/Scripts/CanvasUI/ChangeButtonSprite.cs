using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeButtonSprite : MonoBehaviour
{
    [SerializeField] private Sprite[] sprites;
    [SerializeField] private Button button;
    private void OnMouseEnter()
    {
        button.GetComponent<Image>().sprite = sprites[1]; 
    }
   
    private void OnMouseExit()
    {
        button.GetComponent<Image>().sprite = sprites[0];

    }
}
