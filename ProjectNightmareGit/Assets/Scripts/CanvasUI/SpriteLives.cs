using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class SpriteLives : MonoBehaviour
{
    [SerializeField]
    private Sprite[] hearts;
    void Start()
    {
        ChangeHearts(11);
    }

    public void ChangeHearts(int num)
    {
        print(hearts.Length);
        gameObject.GetComponent<Image>().sprite = hearts[num];
    }
}
