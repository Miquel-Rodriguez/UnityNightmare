using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesapearAtContact : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("RockAttack") || collision.CompareTag("Enemy") || collision.CompareTag("Wall"))
        {
            Destroy(gameObject);
        }
    }
}
