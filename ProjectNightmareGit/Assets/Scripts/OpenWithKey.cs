using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenWithKey : MonoBehaviour
{
    [SerializeField]
    private int numKey;

    private MovimientoPlyaer player;

    private void Awake()
    {
        player = FindObjectOfType<MovimientoPlyaer>();   
    }
    
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (player.takeKey(numKey))
            {
                if (Input.GetKeyDown("c"))
                {
                    BoxCollider2D[] e = GetComponents<BoxCollider2D>();
                    foreach(BoxCollider2D box in e)
                    {
                        box.enabled = false;
                    }
                }                
            }
        }
    }
    
}
