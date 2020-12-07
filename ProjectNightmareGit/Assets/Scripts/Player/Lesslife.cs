using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lesslife : MonoBehaviour
{
    public GameObject target;
    public int life = 100;
    private void OnTriggerEnter2D(Collider2D collision)
        {
         if(collision.tag == "RockAttack")
      {
    life -= 50;
    Debug.Log("me ha dado"+life);
         if (life <= 0)
      {
    Debug.Log("he muerto");
                Destroy(target);    
    }
      }

    }
}
