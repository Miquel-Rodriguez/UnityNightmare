using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GloboCaida : MonoBehaviour
{
    private bool puedes = true;
    private float padre;
    private float hijo;
    private void Start()
    {

        StartCoroutine(ComprobarX());
    }

    private IEnumerator ComprobarX()
    {
        yield return new WaitForSeconds(0.9f);

        transform.Rotate(new Vector3(0f, 0f, 180));
        GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        GetComponent<Animator>().SetBool("explosion", true);
        GetComponent<CircleCollider2D>().enabled = true;
        yield return new WaitForSeconds(0.5f);
        GetComponent<CircleCollider2D>().enabled = true;
       GetComponentInParent<Destroy>().DestroyGameObject();

        
    }
}
