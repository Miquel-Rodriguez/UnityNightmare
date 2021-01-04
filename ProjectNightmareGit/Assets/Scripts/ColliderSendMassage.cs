using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderSendMassage : MonoBehaviour
{
    [SerializeField]
    private string[] taggs;
    [SerializeField]
    private string[] massages;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(taggs[0]))
        {
            collision.SendMessage(massages[0]);
            Destroy(gameObject);
        }
    }

}
