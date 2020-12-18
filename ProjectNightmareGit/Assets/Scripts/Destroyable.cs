﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyable : MonoBehaviour
{
    
    private InsTicket insTicket;
    
    public string destroyState;
    [SerializeField]
    private float timeForDisable;
    private Animator anim;
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }

    IEnumerator OnTriggerEnter2D(Collider2D collision)
    {
        //si colisiona con un objeto con el tag Attack 
        if(collision.tag == "Attack")
        {
            //Instanicar tickets
            insTicket = GameObject.FindGameObjectWithTag("InTicket").GetComponent<InsTicket>();
            insTicket.InstanceTickets(1, 2, gameObject);

            print("destroy");
            //activa animación de destruir
            anim.Play(destroyState);
            //esperamos timeForDisable antes de hacer la siguiente opción
            yield return new WaitForSeconds(timeForDisable);
            Collider2D c = GetComponent<Collider2D>();
            c.enabled = false;
        }
    }

   
  

    void Update()
    {
        //cojemos información de la aimación
        AnimatorStateInfo stateInfo = anim.GetCurrentAnimatorStateInfo(0);

        //si ha acabado la animación destruye el objeto
        if (stateInfo.IsName(destroyState) && stateInfo.normalizedTime >= 1)
        {
            Destroy(gameObject);
        }
            
        
    }
}
