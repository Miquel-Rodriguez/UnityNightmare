using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CPHowPlay : MonoBehaviour
{

   private GameObject panel;
    void Start()
    {
        panel = GameObject.Find("HowPlay").gameObject;
        CerrarHowPlay();
   
    }

    public void CerrarHowPlay()
    {
        panel.SetActive(false);
    }

    public void abrirHowPlay()
    {
        panel.SetActive(true);
    }
}
