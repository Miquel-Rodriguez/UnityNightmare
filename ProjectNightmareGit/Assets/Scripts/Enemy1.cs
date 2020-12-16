using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : MonoBehaviour
{

    public float visionRadius;
    public float attackRadius;
    public float speed;

    private DetectEnemyOpenDoor DetectEnemy;

    public GameObject rockPrefab;
    public float attackSpeed;
    bool attacking;

    public int maxHp = 3;
    public int hp;

    GameObject player;

    Vector3 initialPosition;

    Animator anim;
    Rigidbody2D rb;

        private InsTicket insTicket;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
       
        initialPosition = transform.position;
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        hp = maxHp;

        DetectEnemy = FindObjectOfType<DetectEnemyOpenDoor>();
    }


    void Update()
    {
   
        if (player != null)
        {
        Vector3 target = initialPosition;

        RaycastHit2D hit = Physics2D.Raycast(
            transform.position,
            player.transform.position - transform.position,
            visionRadius,
            //ejecutar el raycast en la capa default
            1 << LayerMask.NameToLayer("Default"));

        Vector3 forward = transform.TransformDirection(player.transform.position - transform.position);
        Debug.DrawRay(transform.position, forward, Color.red);

      
                target = player.transform.position;


        float distance = Vector3.Distance(target, transform.position);
        Vector3 dir = (target - transform.position).normalized;
        if(distance < attackRadius)
        {
            anim.speed=1;
            anim.SetFloat("movX", dir.x);
            anim.SetFloat("movY", dir.y);
            anim.Play("Enemy_walk", -1, 0);
            if (!attacking) StartCoroutine(attack(attackSpeed));
        }
        if(distance<visionRadius && distance > attackRadius)
        {
            rb.MovePosition(transform.position + dir * speed * Time.deltaTime);
            anim.SetFloat("movX", dir.x);
            anim.SetFloat("movY", dir.y);
            anim.SetBool("walking", true);
        }

        if(target == initialPosition && distance < 0.02f)
        {
            transform.position = initialPosition;
            anim.SetBool("walking", false);
        }

        Debug.DrawLine(target, transform.position, Color.green);
        }
        
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, visionRadius);
        Gizmos.DrawWireSphere(transform.position, attackRadius);
    }

    IEnumerator attack(float seconds)
    {
        attacking = true;
        if(rockPrefab != null)
        {
            Instantiate(rockPrefab, transform.position, transform.rotation);
            yield return new WaitForSeconds(seconds);
        }
        attacking = false;
    }

    public void Attacked()
    {
        if (--hp <= 0)
        {
            DetectEnemy.PuedeDesbloquear = true;
            insTicket = GameObject.FindGameObjectWithTag("InTicket").GetComponent<InsTicket>();
            insTicket.InstanceTickets(0, 4, gameObject);
            Destroy(gameObject);
        }
    }

}
