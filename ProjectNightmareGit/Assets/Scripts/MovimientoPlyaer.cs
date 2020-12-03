using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoPlyaer : MonoBehaviour
{
    public float speed = 4f;

    private Animator anim;
    Rigidbody2D rb2d;
    Vector2 mov;

    CircleCollider2D attackCollider;

    //Dash
    public float timeForDisableDash;
    public GameObject chargedAttackPrefab;

    bool movePrevent;


    void Start()
    {
        anim = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
        attackCollider = transform.GetChild(0).GetComponent<CircleCollider2D>();
        attackCollider.enabled = false;

       
    }

    void Update()
    {

        Movements();

        Animations();

        Attack();

        ChargedAttack();

        dash();

        PreventMovement();
    }

    void Movements()
    {
        mov = new Vector2(
           Input.GetAxisRaw("Horizontal"),
           Input.GetAxisRaw("Vertical")
       );
    }

    void Animations()
    {
        if (mov == Vector2.zero){
            anim.SetBool("Walking", false);
        }
        else
        {
            anim.SetFloat("movX", mov.x);
            anim.SetFloat("movY", mov.y);
            anim.SetBool("Walking", true);
        }
    }

    void Attack()
    {
        AnimatorStateInfo stateInfo = anim.GetCurrentAnimatorStateInfo(0);
        bool attacking = stateInfo.IsName("Attack");
        if (Input.GetKeyDown("k") && !attacking)
        {
            anim.SetTrigger("attacking");
        }
        //en conres del mov es poden posar numeros per contrlarlo de forma més exacta(creo)
        if (mov != Vector2.zero) attackCollider.offset = new Vector2(mov.x / 5, mov.y / 5);

        if (attacking)
        {
            float playbackTime = stateInfo.normalizedTime;
            if (playbackTime > 0.33 && playbackTime < 0.66)
            {
                attackCollider.enabled = true;
            }
            else
            {
                attackCollider.enabled = false;
            }

        }
    }


    void dash()
    {
        if (Input.GetKeyDown("e"))

        {
            //Dash Visible (no actua si está quieto)
            //           speed *= 4;
            //            yield return new WaitForSeconds(timeForDisableDash); 
            //             speed /= 4;

            //Dash invisible, se puede ejecutar parado
            //gameObject.transform.Translate(anim.GetFloat("movX"), anim.GetFloat("movY"), 0f);

            //Dash invisible, se puede ejecutar parado
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2 (anim.GetFloat("movX")*200000*Time.deltaTime, anim.GetFloat("movY")*200000 * Time.deltaTime));
        }

    }



    /// /////////////////////////////////////////////chargedAttack no funciona

    void ChargedAttack()
    {
        AnimatorStateInfo stateInfo = anim.GetCurrentAnimatorStateInfo(0);
        bool loading = stateInfo.IsName("player_charged_attack");

        if (Input.GetKeyDown("l"))
        {
            anim.SetTrigger("Loading");
        }
        else if (Input.GetKeyUp("l"))
        {
            anim.SetTrigger("attacking");

            //rotar
            float angle = Mathf.Atan2(
                anim.GetFloat("movY"),
                anim.GetFloat("movX"))
                * Mathf.Rad2Deg;

            GameObject slashObj = Instantiate(
                chargedAttackPrefab, transform.position,
                     Quaternion.AngleAxis(angle, Vector3.forward));


            Slash slash = slashObj.GetComponent<Slash>();
            slash.mov.x = anim.GetFloat("movX");
            slash.mov.y = anim.GetFloat("movY");
        }
    }
    void PreventMovement()
    {
        if (movePrevent)
        {
            mov = Vector2.zero;
        }
    }
    /// /////////////////////////////////////////////


    void FixedUpdate()
    {
        rb2d.MovePosition(rb2d.position + mov * speed * Time.deltaTime);
    }
}