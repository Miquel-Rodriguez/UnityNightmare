using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleAttack : MonoBehaviour
{
    public string collisionTag;
    public string SendMassage;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == collisionTag) collision.SendMessage(SendMassage);
    }
}
