using System.Collections;
using UnityEngine;

public class Boss : MonoBehaviour
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
    bool attacking;
    [SerializeField]
    private float maxHp;
    private float hp;

    private GameObject player;

    private Vector3 initialPosition;

    private Animator anim;
    private Rigidbody2D rb;

    private Renderer renderEnemy;

    private InsTicket insTicket;

    private MovimientoPlyaer playerScript;

    private Transform childAttackBody;
    private Transform childBarrier;
    [SerializeField]
    private GameObject globo;
    private Transform StaticEnemy1;
    private Transform StaticEnemy2;

    private Transform transformSalaBoss;
    private bool activar1 = true;
    private bool activar2 = true;

    void Start()
    {


        player = GameObject.FindGameObjectWithTag("Player");

        initialPosition = transform.position;
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        hp = maxHp;

        renderEnemy = GetComponent<Renderer>();

        playerScript = FindObjectOfType<MovimientoPlyaer>();

        childAttackBody = transform.GetChild(0);
        childBarrier = transform.GetChild(1);
        StaticEnemy1 = transform.GetChild(2);
        StaticEnemy2 = transform.GetChild(3);

        childBarrier.gameObject.SetActive(false);
        StaticEnemy1.gameObject.GetComponent<Animator>().speed = 0;
        StaticEnemy2.gameObject.GetComponent<Animator>().speed = 0;
    }


    void Update()
    {

        if (player != null)
        {
            Vector3 target;

            Vector3 forward = transform.TransformDirection(player.transform.position - transform.position);
            Debug.DrawRay(transform.position, forward, Color.red);


            target = player.transform.position;


            float distance = Vector3.Distance(target, transform.position);
            Vector3 dir = (target - transform.position).normalized;
            if (distance < attackRadius)
            {
                if (!attacking)
                {
                    StartCoroutine(attack(attackSpeed));
                }

            }
            if (distance < visionRadius && distance > attackRadius)
            {

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

        yield return new WaitForSeconds(4);
        childAttackBody.gameObject.GetComponent<Animator>().SetBool("StartRotation", true);
        yield return new WaitForSeconds(0.1f);
        childAttackBody.gameObject.GetComponent<Animator>().SetBool("StartRotation", false);
        yield return new WaitForSeconds(1);
        Barrier(true);
    }

    private void Barrier(bool activate)
    {
        if (activate)
        {
            childBarrier.GetComponent<ScaleGradually>().VolverNormalidad();
            childBarrier.gameObject.SetActive(true);
            DoAttack();
        }
        else childBarrier.gameObject.SetActive(false);
    }

    private void DoAttack()
    {
        /*
        int i = Random.Range(0, 1 + 1);
        if (i == 0)
        {
            
        }
        */
        StartCoroutine(AtaqueLluviaDeGlobos());
    }

    private IEnumerator AtaqueLluviaDeGlobos()
    {
        print("Inicio lluvia globos");
        transformSalaBoss = transform.GetComponentInParent<Transform>();
        for (int k = 0; k < 5; k++)
        {
            for (int i = 0; i < 5; i++)
            {

                Instantiate(globo, new Vector3(transformSalaBoss.position.x + Random.Range(-8, 9 + 1), transformSalaBoss.position.y + Random.Range(-7, 10 + 1), 0f), Quaternion.identity);
            }
            yield return new WaitForSeconds(0.3f);
        }
        yield return new WaitForSeconds(2f);
        print("Final lluvia globos");
        Barrier(false);
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
        if (hp <= maxHp / 3 && activar1)
        {
            print("activando enemigos");
            StaticEnemy1.gameObject.GetComponent<Animator>().speed = 1;
            StaticEnemy1.GetComponent<EStatic4>().comproba = true;
            activar1 = false;
        }
        if (hp <= maxHp / 3 * 2 && activar2)
        {
            StaticEnemy2.GetComponent<EStatic4>().comproba = true;
            StaticEnemy2.gameObject.GetComponent<Animator>().speed = 1;
            activar2 = false;
        }
    }

    public IEnumerator Morir()
    {
        GetComponent<CircleCollider2D>().enabled = true;
        insTicket = FindObjectOfType<InsTicket>();
        insTicket.InstanceItems(gameObject);
        yield return new WaitForSeconds(0.1f);
        Destroy(gameObject);
    }

    public void MoveForce(Vector2 v)
    {
        rb.AddForce(v * 100000);
        // new Vector3(transform.position.x, transform.position.y)
    }

    public IEnumerator CambiarColor()
    {
        renderEnemy.material.SetColor("_Color", Color.red);
        yield return new WaitForSeconds(0.1f);
        renderEnemy.material.SetColor("_Color", Color.white);
    }
}
