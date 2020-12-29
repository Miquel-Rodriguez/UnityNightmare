using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSprites : MonoBehaviour
{
    [SerializeField]
    private Sprite[] sprites;
    void Start()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = sprites[Random.Range(0,sprites.Length)];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
