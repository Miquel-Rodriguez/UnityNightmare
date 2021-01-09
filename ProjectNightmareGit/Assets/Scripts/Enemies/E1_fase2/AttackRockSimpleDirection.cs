using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackRockSimpleDirection : MonoBehaviour
{
    [SerializeField]
    private float speed;

    private GameObject player;
    private Rigidbody2D rg;
    private Vector3 target, dir;
    private bool positive = true;

    public bool Positive { get { return positive; } set { positive = value; } }

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        rg = GetComponent<Rigidbody2D>();

        if (player != null){
            target = player.transform.position;
            dir = (target - transform.position).normalized;
    
        }
        StartCoroutine(SearchObjective());
        StartCoroutine(WaitForDestroy());
    }

    public IEnumerator WaitForDestroy()
    {
        yield return new WaitForSeconds(7);
        Destroy(gameObject);
    }
    public IEnumerator SearchObjective()
    {
        while (true)
        {
            if (player != null)
            {
                 target = player.transform.position; 
                 dir = (target - transform.position).normalized;
                 
            }
            yield return new WaitForSeconds(1);
        }
       
    }


    private void FixedUpdate()
    {
            rg.MovePosition(transform.position + (dir * Random.Range(1, speed + 1)) * Time.deltaTime);              
    }
    private void OnTriggerEnter2D (Collider2D collision)
    {
        if(collision.transform.CompareTag("BoxPlayer") || collision.transform.CompareTag("Attack") || collision.transform.CompareTag("Wall") || collision.transform.CompareTag("Door"))
        {
            Destroy(gameObject);
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

}
