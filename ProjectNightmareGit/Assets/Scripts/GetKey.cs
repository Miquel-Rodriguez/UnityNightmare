using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetKey : MonoBehaviour
{
    private MovimientoPlyaer player;

    [SerializeField]
    private int numKey;
    private void Awake()
    {
        player = FindObjectOfType<MovimientoPlyaer>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("BoxPlayer"))
        {
            player.putKey(numKey);
            Destroy(gameObject);
        }
    }
}
