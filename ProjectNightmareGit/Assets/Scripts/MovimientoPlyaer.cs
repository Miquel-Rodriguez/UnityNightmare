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

    //////////////
    public GameObject chargedAttackPrefab;

    public int maxLife = 100;
    private int life;

    bool movePrevent;

    //ataque a distancia
    public GameObject arrowprefab;
    float arrowRotation = 0;
    private float nextFireTime =0;
    public float cooldawnFlecha=2;

    void Start()
    {
        //inicializamos las variables con los componentes del objeto
        anim = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
        attackCollider = transform.GetChild(0).GetComponent<CircleCollider2D>();
        attackCollider.enabled = false;
        life = maxLife;
    }

    void Update()
    {
        Movements();

        Animations();

        Attack();

        ChargedAttack();

        LanzarAtaque();

        dash();

        PreventMovement();
    }

    void LanzarAtaque()
    {
        
        if (Time.time >= nextFireTime)
        {
            if (Input.GetKeyDown("1"))
            {
                nextFireTime = Time.time + cooldawnFlecha;

                //Hacer la variación de grados según la posición de movimiento
                arrowRotation = Mathf.Atan2(
                anim.GetFloat("movY"),
                anim.GetFloat("movX"))
                * Mathf.Rad2Deg;

                //instanciar el objeto arraowprefab
                Instantiate(arrowprefab, transform.position, Quaternion.Euler(0, 0, arrowRotation + 90));
            }
        }
    }


    void Movements()
    {
        //Indicar hacía donde sera el movimiento poniendo la dirección en un vector2
        mov = new Vector2(
           Input.GetAxisRaw("Horizontal"),
           Input.GetAxisRaw("Vertical")
       );

        //Forma2 de mover
        rb2d.AddForce(mov * speed * Time.deltaTime);
    }

    //hacer las animaciones de caminar según los ejes x e y
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
        //cojer la información de la animación de ataque
        AnimatorStateInfo stateInfo = anim.GetCurrentAnimatorStateInfo(0);
        bool attacking = stateInfo.IsName("Attack");

        //si pulsamos k activamos la animación de atacar
        if (Input.GetKeyDown("k") && !attacking)
        {
            anim.SetTrigger("attacking");
        }

        //reposicionar el BoxCollider del ataque según la dirección en la que nos movemos
        if (mov != Vector2.zero) attackCollider.offset = new Vector2(mov.x / 5, mov.y / 5);

        if (attacking)
        {
            //Activar el boxCollider solo cuando la animación esté a mitad del precoso
            //es para hacerlo más relista()
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
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2 (anim.GetFloat("movX")*100000*Time.deltaTime, anim.GetFloat("movY")*100000 * Time.deltaTime));
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
        //Forma de mover num 1
        //rb2d.MovePosition(rb2d.position + mov * speed * Time.deltaTime);
    }

}