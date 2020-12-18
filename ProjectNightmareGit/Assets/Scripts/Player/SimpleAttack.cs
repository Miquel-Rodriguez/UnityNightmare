using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleAttack : MonoBehaviour
{
    [SerializeField]
    private string [] collisionTag;
    [SerializeField]
    private string [] SendMassage;

    private GameObject player;
    private Animator AnimP;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        AnimP = player.GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Vector2 v =new Vector2(AnimP.GetFloat("movX"), AnimP.GetFloat("movY"));

        if (collision.CompareTag(collisionTag[0]))
        {
            collision.SendMessage(SendMassage[0]);
            collision.SendMessage(SendMassage[1], v);

        }
        
    }
}
