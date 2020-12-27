using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EStatic4 : MonoBehaviour
{
    [SerializeField]
    private GameObject rockPrefab;
    [SerializeField]
    private float speed;

    private GameObject rock;
    void Start()
    {
        StartCoroutine(Attack());
    }

    public IEnumerator Attack()
    {
        while (true)
        {
            yield return new WaitForSeconds(1.5f);
            InstanceAndForce(1, 1);
            InstanceAndForce(-1, -1);
            InstanceAndForce(1, -1);
            InstanceAndForce(-1, 1);

            yield return new WaitForSeconds(1.5f);
            InstanceAndForce(-1, 0);
            InstanceAndForce(0, -1);
            InstanceAndForce(1, 0);
            InstanceAndForce(0, 1);
            
        }

    }

    private void InstanceAndForce(float x, float y)
    {
        rock = Instantiate(rockPrefab, new Vector2(transform.position.x+x/6, transform.position.y+y/6), transform.rotation);
        rock.GetComponent<Rigidbody2D>().AddForce(new Vector2(x, y) * speed);
    }

    
    void Update()
    {
        
    }
}
