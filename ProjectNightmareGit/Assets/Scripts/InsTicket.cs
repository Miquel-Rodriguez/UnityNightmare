using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InsTicket : MonoBehaviour
{
    [SerializeField]
    private GameObject ticket;

    [SerializeField]
    private GameObject [] hearts;

    private Vector3 v;

    private Lesslife player;


    private void Awake()
    {
        player = FindObjectOfType<Lesslife>();
    }
    public void InstanceItems(GameObject go)
    {
        v = go.transform.position;
        InstanceHearts();
        InstanceTickets();
        

       
    }

    public void InstanceTickets()
    {
        for (int i = 0; i < player.Life; i++) {
            int num = Random.Range(0,1+1);
            for (int j = 0; j < num; j++)
            {
                GameObject instance = Instantiate(ticket, new Vector2(v.x, v.y), Quaternion.identity);
                instance.GetComponent<Rigidbody2D>().AddForce(new Vector2(RandomF(), RandomF()));
                instance.transform.SetParent(transform);
            }
        }

        
    }
    /*
    public void NumHearts()
    {
        if (Random.Range(0, 1 + 1) == 1)
        {
            if (player.Life >= 10)
            {
                InstanceHearts(1);
            }
            else if (player.Life >= 7)
            {
                InstanceHearts(2);
            }
            else if (player.Life >= 4)
            {
                InstanceHearts(3);
            }
            else
            {
                InstanceHearts(4);
            }
        }
    }
    */
    public void InstanceHearts()
    {
        for(int i = 11; i > player.Life; i-=3)
        {
            if (Random.Range(0, 7 + 1) == 1){ 
            GameObject instance = Instantiate(hearts[Random.Range(0, 1 + 1)], new Vector2(v.x, v.y), Quaternion.identity);
            instance.GetComponent<Rigidbody2D>().AddForce(new Vector2(RandomF(), RandomF()));
            instance.transform.SetParent(transform);
            }
        }
    }




    public float RandomF()
    {
        return Random.Range(-140, 140);

    }

}
