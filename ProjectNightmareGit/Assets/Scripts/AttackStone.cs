using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackStone : MonoBehaviour
{
    [SerializeField]
    private float speed;

    private GameObject player;
    private Rigidbody2D rg;
    private Vector3 target, dir;
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
        print("comprobando trigeer");
        if (collision.transform.CompareTag("BoxPlayer") || collision.transform.CompareTag("Attack") || collision.transform.CompareTag("Wall") || collision.transform.CompareTag("Door"))
        {
            Destroy(gameObject);
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
