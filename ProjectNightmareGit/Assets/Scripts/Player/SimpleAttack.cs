using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleAttack : MonoBehaviour
{
    [SerializeField]
    private string collisionTag;
    [SerializeField]
    private string SendMassage;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag(collisionTag)) collision.SendMessage(SendMassage);
    }
}
