using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenWithKey : MonoBehaviour
{
    [SerializeField]
    private int numKey;
    [SerializeField]
    private Canvas canvas;
        
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
                canvas.enabled = true;
                if (Input.GetKeyDown("c"))
                {
                    canvas.enabled = false;
                    BoxCollider2D[] e = GetComponents<BoxCollider2D>();
                    foreach(BoxCollider2D box in e)
                    {
                        box.enabled = false;
                        GetComponentInParent<Animator>().SetBool("open", true);
                        
                        
                    }
                }                
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) canvas.enabled = false;
    }

}
