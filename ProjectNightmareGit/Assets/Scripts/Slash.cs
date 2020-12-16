using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slash : MonoBehaviour
{

    [SerializeField]
    private float waitForDestroy;
    [SerializeField]
    private float speed;
    [HideInInspector]
    public Vector2 mov;

    private void Start()
    {
        transform.position = new Vector3(mov.x, mov.y, 0);
    }
    void Update()
    {
        transform.position = new Vector3(mov.x, mov.y, 0) * speed * Time.deltaTime;
        
    }

    private IEnumerator OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Objcet")
        {
            yield return new WaitForSeconds(waitForDestroy);
            Destroy(gameObject);
        }else if(collision.tag != "Player" && collision.tag != "Attack")
            Destroy(gameObject);
        
    }
}
