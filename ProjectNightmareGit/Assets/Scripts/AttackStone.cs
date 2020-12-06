using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackStone : MonoBehaviour
{
    public float speed;

    GameObject player;
    Rigidbody2D rg;
    Vector3 target, dir;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        rg = GetComponent<Rigidbody2D>();

        if (player != null){
            target = player.transform.position;
            dir = (target - transform.position).normalized;
    
        }
    }

    private void FixedUpdate()
    {
        if (target != Vector3.zero)
        {
            rg.MovePosition(transform.position + (dir * speed) * Time.deltaTime);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.tag == "BoxPlayer" || collision.transform.tag == "Attack")
        {
            Destroy(gameObject);
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
