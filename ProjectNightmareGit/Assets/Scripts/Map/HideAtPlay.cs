using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideAtPlay : MonoBehaviour
{
    void Start(){
        transform.GetComponent<SpriteRenderer>().enabled = false;
        foreach (Transform child in transform){
            child.GetComponent<SpriteRenderer>().enabled = false;
        }
        
        
    } 
}
