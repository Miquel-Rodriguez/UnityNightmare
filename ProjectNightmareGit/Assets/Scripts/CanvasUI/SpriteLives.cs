﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class SpriteLives : MonoBehaviour
{
    [SerializeField]
    private Sprite[] hearts;
    void Start()
    {
        ChangeHearts(12);
    }

    public void ChangeHearts(int num)
    {
        gameObject.GetComponent<Image>().sprite = hearts[num];
    }
}
