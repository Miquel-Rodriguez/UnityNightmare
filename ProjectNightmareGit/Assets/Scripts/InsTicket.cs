using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InsTicket : MonoBehaviour
{
    [SerializeField]
    private GameObject ticket;
    private Vector3 v;
   
   public void InstanceTickets(int min, int max, GameObject go)
    {
        int num = Random.Range(min, max);
        v=go.transform.position;
        for (int i = 0; i < num; i++)
        {
            GameObject instance = Instantiate(ticket, new Vector3(v.x, v.y, 0f), Quaternion.identity);

            float vX = Random.Range(-130, 130);
            float vY = Random.Range(-130, 130);

            instance.GetComponent<Rigidbody2D>().AddForce(new Vector2(vX, vY));
        }
    }
}
