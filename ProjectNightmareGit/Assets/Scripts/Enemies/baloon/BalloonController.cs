using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonController : MonoBehaviour
{
    private Renderer renderEnemy;
    private Animator anim;
    private BalloonEnemy parentScript;
    private bool exploting = false;
    private PolygonCollider2D polyCollider;
    private DetectEnemyOpenDoor DetectEnemy;
    void Start()
    {
        renderEnemy = GetComponent<Renderer>();
        anim = GetComponent<Animator>();
        parentScript = GetComponentInParent<BalloonEnemy>();
        polyCollider = GetComponent<PolygonCollider2D>();
     
    }

   


    public IEnumerator CambiarColor(float tEspera, int vagades)
    {
        int i = 0;
        do
        {
            renderEnemy.material.SetColor("_Color", Color.red);
           
            renderEnemy.material.SetColor("_Color", Color.white);
            i++;
            yield return new WaitForSeconds(tEspera/2);
        } while (i < vagades);
        i = 0;
        do
        {
            renderEnemy.material.SetColor("_Color", Color.red);
            yield return new WaitForSeconds(tEspera / 4);
            renderEnemy.material.SetColor("_Color", Color.white);
            i++;
            yield return new WaitForSeconds(tEspera / 4);
        } while (i < vagades * 2);

        i = 0;
        do
        {
            renderEnemy.material.SetColor("_Color", Color.red);
            yield return new WaitForSeconds(tEspera / 6);
            renderEnemy.material.SetColor("_Color", Color.white);
            i++;
            yield return new WaitForSeconds(tEspera / 6);
        } while (i < vagades * 3);
        StartCoroutine(Attack());
    }

    public IEnumerator Attack()
    {
       
        StartCoroutine(parentScript.EnableCircleCollider());
        anim.SetBool("explosion", true);

        parentScript.DestroyChild();
        yield return new WaitForSeconds(0.8f);
        parentScript.DestroyObject();
    }

   

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Attack"))
        {
            polyCollider.enabled = false;
            StartCoroutine(Attack()) ;

        }
    }

}
