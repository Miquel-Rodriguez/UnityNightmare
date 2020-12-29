using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideAtPlay : MonoBehaviour
{
    void Start(){
        foreach(Transform child in transform){
             foreach(Transform child2 in child.GetComponent<Transform>()){
                       child2.GetComponent<SpriteRenderer>().enabled = false;
             }
            child.GetComponent<SpriteRenderer>().enabled = false;
        }
    } 
}
