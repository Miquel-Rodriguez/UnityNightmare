using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E1Two : MonoBehaviour
{
    [SerializeField]
    private float visionRadius;
    [SerializeField]
    private float attackRadius;
    [SerializeField]
    private float speed;

    [SerializeField]
    private GameObject rockPrefab;
    [SerializeField]
    private float attackSpeed;
    bool attacking;
    [SerializeField]
    private float maxHp = 3;
    private float hp;

    private GameObject player;

    private Vector3 initialPosition;

    private Animator anim;
    private Rigidbody2D rb;

    private Renderer renderEnemy;

    private InsTicket insTicket;

    private MovimientoPlyaer playerScript;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        initialPosition = transform.position;
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        hp = maxHp;

        renderEnemy = GetComponent<Renderer>();

        playerScript = FindObjectOfType<MovimientoPlyaer>();

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
            


            target = player.transform.position;


            float distance = Vector3.Distance(target, transform.position);
            Vector3 dir = (target - transform.position).normalized;
            if (distance < attackRadius)
            {
                anim.speed = 1;
                anim.SetFloat("movX", dir.x);
                anim.SetFloat("movY", dir.y);
                anim.Play("Enemy_walk", -1, 0);
                if (!attacking) StartCoroutine(attack(attackSpeed));
            }
            if (distance < visionRadius && distance > attackRadius)
            {
                rb.MovePosition(transform.position + dir * speed * Time.deltaTime);
                anim.SetFloat("movX", dir.x);
                anim.SetFloat("movY", dir.y);
                anim.SetBool("walking", true);
            }



       
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
        if (rockPrefab != null)
        {
            renderEnemy.material.SetColor("_Color", Color.magenta);
            yield return new WaitForSeconds(0.2f);           
            Instantiate(rockPrefab, transform.position, transform.rotation);
            renderEnemy.material.SetColor("_Color", Color.white);
            yield return new WaitForSeconds(seconds);
        }
        attacking = false;
    }

    public void Attacked()
    {
        float d = playerScript.damageV;
        StartCoroutine(CambiarColor());
        if ((hp -= d) <= 0)
        {
            StartCoroutine(Morir());


        }
    }

    public IEnumerator Morir()
    {
        GetComponent<CircleCollider2D>().enabled = true;
        insTicket = FindObjectOfType<InsTicket>();
        insTicket.InstanceItems(gameObject);
        yield return new WaitForSeconds(0.02f);
        Destroy(gameObject);
    }

    public void MoveForce(Vector2 v)
    {
        if (hp <= 0)
        {
           
        }
        else rb.AddForce(v * 100000);

        // new Vector3(transform.position.x, transform.position.y)
    }

    public IEnumerator CambiarColor()
    {
        renderEnemy.material.SetColor("_Color", Color.red);
        yield return new WaitForSeconds(0.1f);
        renderEnemy.material.SetColor("_Color", Color.white);
    }
}
