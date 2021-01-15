using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class OpenWithKey : MonoBehaviour
{
    [SerializeField]
    private int numKey;
    [SerializeField]
    private string nameCanvas;
    private Canvas canvas;

    private MovimientoPlyaer player;

    private void Start()
    {
        canvas = GameObject.Find(nameCanvas).GetComponent<Canvas>();
        player = FindObjectOfType<MovimientoPlyaer>();   
    }
    
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (player.takeKey(numKey))
            {
                canvas.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = "Pulsa C para abrir la puerta";
                canvas.enabled = true;
                if (Input.GetKeyDown("c"))
                {
                    canvas.enabled = false;
                    BoxCollider2D[] e = GetComponents<BoxCollider2D>();
                    foreach(BoxCollider2D box in e)
                    {
                        box.enabled = false;
                        GetComponentInParent<Animator>().SetBool("open", true);

                        GetComponent<AudioSource>().Play();
                        GetComponentInParent<OpenDKSound>().playOpen();
                    }
                }                
            }
            else
            {
                canvas.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = "Necesitas una llave para habrir la puerta";
                canvas.enabled = true;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) canvas.enabled = false;
    }

}
