﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lesslife : MonoBehaviour
{
    [SerializeField]
    private GameObject target;
    [SerializeField]
    private int life;

    private SpriteLives spriteLives;

    private GameObject player;
    private Renderer playerRender;

    private Color ColorT;
    private Color ColorV;

    private bool golpeable=true;
    [SerializeField]
    private Transform checkPoint;
    public int Life
    {
        get { return life; }
    }



    public void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerRender = player.GetComponent<Renderer>();

        spriteLives = GameObject.FindObjectOfType<SpriteLives>();

        ColorT = new Color(playerRender.material.color.r, playerRender.material.color.g, playerRender.material.color.b, 0);
        ColorV = new Color(playerRender.material.color.r, playerRender.material.color.g, playerRender.material.color.b, 1);
    }
    private void OnTriggerEnter2D(Collider2D collision){
        
        if(golpeable){
            
            if (collision.CompareTag("RockAttack"))
            {
                TakeDamage(1);
                StartCoroutine(CambiarTransperencia());
                
            }else if (collision.CompareTag("explosion"))
            {
                TakeDamage(3);
                StartCoroutine(CambiarTransperencia());
            }
        }

        if (collision.CompareTag("heart"))
        {
            if (life < 11)
            {
                life+=2;
                ChangeSpritesLife();
                collision.GetComponent<HeartScript>().Desapear();
                
            }
        }

        if (collision.CompareTag("mediumHeart"))
        {
            if (life <= 11)
            {
                life += 1;
                ChangeSpritesLife();
                collision.GetComponent<HeartScript>().Desapear();
            }
        }
    }

    public void HealOne()
    {
        life += 1;
        ChangeSpritesLife();
    }

    public void RestoreLife()
    {
        life = 12;
        ChangeSpritesLife();
    }


    public void TakeDamage(int damage)
    {
        golpeable = false;
        life -= damage;

        ChangeSpritesLife();

        if (life <= 0)
        {
            Debug.Log("he muerto");
            Die();
        }
    }

    public void ChangeSpritesLife()
    {
        spriteLives.ChangeHearts(life);
    }




    public IEnumerator CambiarTransperencia()
    {
        int i = 0;
        do
        {
            playerRender.material.color = ColorT;
            yield return new WaitForSeconds(0.1f);
            playerRender.material.color = ColorV;
            i++;
            yield return new WaitForSeconds(0.1f);
        } while (i < 5);
        golpeable = true;
    }

    private void Die()
    {
       GameObject.Find("Player").gameObject.transform.position = checkPoint.position;
        FindObjectOfType<ChangeCamera>().ActivateAllCameras();
        
        FindObjectOfType<RoomControl>().RoomsControl();
     
    }

}
