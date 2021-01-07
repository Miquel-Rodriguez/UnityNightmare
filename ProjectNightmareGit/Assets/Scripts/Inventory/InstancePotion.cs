using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstancePotion : MonoBehaviour
{

    [SerializeField]
    GameObject potion;

    [SerializeField]
    Transform player;
    public void InstancePoti()
    {
        if (FindObjectOfType<MovimientoPlyaer>().Tickets >= 10)
        {
            FindObjectOfType<MovimientoPlyaer>().Tickets -= 10;          
            FindObjectOfType<MovimientoPlyaer>().UploadTickets();
            Instantiate(potion, new Vector2(player.position.x, player.position.y), Quaternion.identity);
            

        }
        
    }
}
