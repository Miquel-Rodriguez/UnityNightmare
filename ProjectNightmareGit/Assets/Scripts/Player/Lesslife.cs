using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lesslife : MonoBehaviour
{
    [SerializeField]
    private GameObject target;
    [SerializeField]
    private int life = 12;
    [SerializeField]
    private SpriteLives spriteLives;

    public void Awake()
    {
        spriteLives = GameObject.FindObjectOfType<SpriteLives>();
    }
    private void OnTriggerEnter2D(Collider2D collision){
         if(collision.tag == "RockAttack"){
            life -= 1;
            Debug.Log("me ha dado"+life);

            spriteLives.ChangeHearts(life);
            
            if (life <= 0){
                Debug.Log("he muerto");
                Destroy(target);    
            }
         }
    }
}
