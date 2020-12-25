using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonEnemy : MonoBehaviour
{
    [SerializeField]
    private float visionRadius;
    [SerializeField]
    private float attackRadius;
    [SerializeField]
    private float speed;

    private DetectEnemyOpenDoor DetectEnemy;

    [SerializeField]
    private GameObject rockPrefab;
    [SerializeField]
    private float attackSpeed;
    bool attacking ;
    [SerializeField]
    private int maxHp = 3;
    private int hp;

    private GameObject player;

    private Vector3 initialPosition;

    private Animator anim;
    private Rigidbody2D rb;

    private Renderer renderEnemy;

    private InsTicket insTicket;

    private MovimientoPlyaer playerScript;

    private CircleCollider2D damageRadius;
    private PolygonCollider2D polyCollider;

    private BalloonController childScript;

    private bool go = true;
    private bool exploting = false;

    public void Awake()
    {
        
    }

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        initialPosition = transform.position;
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        hp = maxHp;

        DetectEnemy = FindObjectOfType<DetectEnemyOpenDoor>();

        renderEnemy = GetComponent<Renderer>();

        playerScript = FindObjectOfType<MovimientoPlyaer>();

        damageRadius = GetComponent<CircleCollider2D>();

 
        childScript = GetComponentInChildren<BalloonController>();
        
    }


    void Update()
    {
        if (go)
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
                if (distance < attackRadius)
                {

                    StartCoroutine(childScript.CambiarColor(1f, 2));
                    go = false;

                }
                if (distance < visionRadius && distance > attackRadius)
                {
                    rb.MovePosition(transform.position + dir * speed * Time.deltaTime);

                }


                Debug.DrawLine(target, transform.position, Color.green);
            }
        }
      
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, visionRadius);
        Gizmos.DrawWireSphere(transform.position, attackRadius);
    }



    public void MoveForce(Vector2 v)
    {

    }

    public IEnumerator EnableCircleCollider()
    {
        damageRadius.enabled = true;
        yield return new WaitForSeconds(0.4f);
        damageRadius.enabled = false;
    }

    public void DestroyObject()
    {
        Destroy(gameObject);
    }

 

    public void Attacked()
    {

    }

    public void AddParent()
    {
        DetectEnemy = GetComponent<DetectEnemyOpenDoor>();
    }
}
