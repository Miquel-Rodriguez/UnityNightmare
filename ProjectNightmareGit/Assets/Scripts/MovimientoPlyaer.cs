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
    public float dashSpeed;
    private float dashTime;
    public float startDashTime;
    private int direction;
    public float timeForDisableDash;


    void Start()
    {
        anim = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
        attackCollider = transform.GetChild(0).GetComponent<CircleCollider2D>();
        attackCollider.enabled = false;

        //dash
        dashTime = startDashTime;
    }

    void Update()
    {

        mov = new Vector2(
            Input.GetAxisRaw("Horizontal"),
            Input.GetAxisRaw("Vertical")
        );

        if(mov == Vector2.zero)
        {
            anim.SetBool("Walking", false);
        }
        else
        {
            anim.SetFloat("movX", mov.x);
            anim.SetFloat("movY", mov.y);
            anim.SetBool("Walking", true);
        }

        AnimatorStateInfo stateInfo = anim.GetCurrentAnimatorStateInfo(0);
        bool attacking = stateInfo.IsName("Attack");
        if(Input.GetKeyDown("k") && !attacking)
        {
            anim.SetTrigger("attacking");
        }
        //en conres del mov es poden posar numeros per contrlarlo de forma més exacta(creo)
        if (mov != Vector2.zero) attackCollider.offset = new Vector2(mov.x/5,mov.y/5);

        if (attacking)
        {
            float playbackTime = stateInfo.normalizedTime;
            if (playbackTime > 0.33 && playbackTime < 0.66)
            {
                attackCollider.enabled = true;
            }
            else { 
                attackCollider.enabled = false;
            } 

        }

        StartCoroutine(
                //Dash
                dash());
    }

    IEnumerator dash()
    {
        if (Input.GetKeyDown("e"))
        {
            speed *= 4;
            yield return new WaitForSeconds(timeForDisableDash);
            speed /= 4;
        }

    }

    
    void FixedUpdate()
    {
        rb2d.MovePosition(rb2d.position + mov * speed * Time.deltaTime);
    }
}