using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoPlyaer : MonoBehaviour
{

    [SerializeField]
    private float speed;

    public float speedV { get { return speed;} set{ speed = value;}}

    private Animator anim;
    private Rigidbody2D rb2d;
    private Vector2 mov;

    private CircleCollider2D attackCollider;
    private CircleCollider2D ChargeAttackCollider;


    [SerializeField]
    private GameObject ChargedAttackPrefab;

    public bool movePrevent;

    private float timeForDisableDash = 0.1f;

    //ataque a distancia
    [SerializeField]
    private GameObject DistanceAttackprefab;
    private float DistanceAttackRotation;
    private float nextFireTime;
    private float cooldawnDistanceAttack = 2;

    private TicketsUI ticketsUI;
    private int InitialTtickets = 0;
    
    public int Tickets { get; set; }
    private bool attacking=false;

    private bool upKeyL = true;
    private float tiempo;

    private bool[] keys;
    public void putKey(int pos)
    {
        keys[pos] = true;
    }

    public bool takeKey(int pos)
    {
        return keys[pos];
    }

    public void PutKeysInFalse(int inici, int numK)
    {
        for ( inici = 1; inici <= numK; inici++) { 
       
            keys[inici] = false;
        }
    }

    private float damage = 1;
    public float damageV { get{ return damage; } set { damage = value;} }


    public bool haveSlash { get; set; }

    public bool imLiving = true;


    void Start()
    {
       
        //inicializamos las variables con los componentes del objeto
        anim = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
        attackCollider = transform.GetChild(0).GetComponent<CircleCollider2D>();
        attackCollider.enabled = false;

        ChargeAttackCollider = transform.GetChild(2).GetComponent<CircleCollider2D>();
        ChargeAttackCollider.enabled = false;

        Tickets = InitialTtickets;

 
        ticketsUI = GameObject.FindObjectOfType<TicketsUI>();

        keys = new bool[10];
    }

    void Update()
    {
        if (imLiving)
        {
            Movements();

            Animations();

            Attack();


            ChargedAttack();


            if (haveSlash && Input.GetKeyDown("1") && Time.time >= nextFireTime)
            {
                LanzarHabilidad();
            }


            if (Input.GetKeyDown("j"))
            {
                if (speed == 0)
                {
                    //ponerse escudo para parar daño
                }
                else
                {
                    StartCoroutine(dash());
                }

            }

            PreventMovement();
            if (!upKeyL)
            {
                TimeChargeAttack();
            }
            else tiempo = 0;
        }
        else
        {
            movePrevent = true;
            PreventMovement();
        }
    }

    public void TimeChargeAttack()
    {
      tiempo += Time.deltaTime;
      print(tiempo);
      if (tiempo < 1)
      {
      //perticulas 1
      }
      if(tiempo < 2)
      {
      //particulas 2
     }

    }



    void LanzarHabilidad()
    {
        nextFireTime = Time.time + cooldawnDistanceAttack;

        //Hacer la variación de grados según la posición de movimiento
        DistanceAttackRotation = Mathf.Atan2(
        anim.GetFloat("movY"),
        anim.GetFloat("movX"))
        * Mathf.Rad2Deg;

        //instanciar el objeto arraowprefab
        Instantiate(DistanceAttackprefab, transform.position, Quaternion.Euler(0, 0, DistanceAttackRotation + 90));
        
    }


    void Movements()
    {
        //Indicar hacía donde sera el movimiento poniendo la dirección en un vector2
        mov = new Vector2(
           Input.GetAxisRaw("Horizontal"),
           Input.GetAxisRaw("Vertical")
       );
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
        attacking = stateInfo.IsName("Attack");

        //si pulsamos k activamos la animación de atacar
        if (Input.GetKeyDown("k") && !attacking)
        {
            anim.SetTrigger("attacking");
        }

        //reposicionar el BoxCollider del ataque según la dirección en la que nos movemos
        if (mov != Vector2.zero) attackCollider.offset = new Vector2(mov.x/ 5 , mov.y / 5);

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


    public IEnumerator dash()
    {
            //Dash Visible (no actua si está quieto)
            //print("key e");
            speed *= 4;
            yield return new WaitForSeconds(timeForDisableDash);
            speed /= 4;

            //Dash invisible, se puede ejecutar parado
            //gameObject.transform.Translate(anim.GetFloat("movX"), anim.GetFloat("movY"), 0f);

            //Dash invisible, se puede ejecutar parado
            //gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2 (anim.GetFloat("movX")*100000*Time.deltaTime, anim.GetFloat("movY")*100000* Time.deltaTime));
    }




    void ChargedAttack()
    {
        
        if (Input.GetKeyDown("l"))
        {
            anim.SetTrigger("Loading");
            movePrevent = true;
            upKeyL = false;

        }
        else if (Input.GetKeyUp("l"))
        {
            upKeyL = true;
            if (tiempo < 1)
            {
            }
            else if(tiempo>=1 && tiempo < 2)
            {
                damageV += 2;
            }
            else if (tiempo >= 2){
                damageV += tiempo;
            }

            movePrevent = false;
            
            anim.SetTrigger("ChargeAttack");
            ChargeAttackCollider.offset = new Vector2(anim.GetFloat("movX") * 1.6f, anim.GetFloat("movY") / 2.5f);

            StartCoroutine(Wait(0.1f));

            // Slash slash = slashObj.GetComponent<Slash>();
            //slash.mov.x = anim.GetFloat("movX");
            //slash.mov.y = anim.GetFloat("movY");


        }
    }

    public IEnumerator Wait(float s)
    {
        yield return new WaitForSeconds(s);
        ChargeAttackCollider.enabled = true;
        yield return new WaitForSeconds(s);
        ChargeAttackCollider.enabled = false;
    }

    void PreventMovement()
    {
        if (movePrevent)
        {
            mov = Vector2.zero;
        }
    }


    void FixedUpdate()
    {
        // Forma de mover num 1
        // rb2d.MovePosition(rb2d.position + mov * speed * Time.deltaTime);
        //Forma2 de mover 
        rb2d.AddForce(mov * speed * Time.deltaTime);

        //if (Input.GetKeyDown("e"))
        //{
          //  print("key e");
        //    rb2d.AddForce(new Vector2(anim.GetFloat("movX") * 100000 * Time.deltaTime, anim.GetFloat("movY") * 100000 * Time.deltaTime));
      //  }
        
    }

    public void PlusTicket()
    {
        Tickets++;
        UploadTickets();
    }

    public void UploadTickets()
    {
        ticketsUI.changeTicketsText(Tickets);
        FindObjectOfType<Inventory>().InventoriLessTickets();
    }
    

}