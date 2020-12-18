using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HabilitiAttack : MonoBehaviour
{
    [SerializeField]
    private string [] collisionTag;
    [SerializeField]
    private string [] SendMassage;

    private GameObject player;
    private Animator AnimP;

    private Transform tranform;
    private Vector2 v;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        AnimP = player.GetComponent<Animator>();
        
        tranform = gameObject.transform;
        v =new Vector2(AnimP.GetFloat("movX"), AnimP.GetFloat("movY"));
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
       

        if (collision.CompareTag(collisionTag[0]))
        {
            collision.SendMessage(SendMassage[0]);
            collision.SendMessage(SendMassage[1], v);

        }
        
    } 
}


