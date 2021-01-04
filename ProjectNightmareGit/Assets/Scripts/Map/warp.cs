using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class warp : MonoBehaviour
{
    [SerializeField]
    private GameObject target;
    /*
    [SerializeField]
    private GameObject Targetmap;
    */
    [SerializeField]
    private GameObject camera;
    
    [SerializeField]
    private CompositeCollider2D limits;



    private bool start = false;
    private bool isFadeIn = false;
    private float alpha = 0;
    private float fadeTime=0.5f;
    IEnumerator OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
            FadeIn();
            yield return new WaitForSeconds(fadeTime);

            ChangeCamera change = gameObject.GetComponent<ChangeCamera>();
            if (change != null)
            {
                change.ChangeCameras();
            }
            other.transform.position = target.transform.GetChild(0).transform.position;
            other.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            if (camera != null)
            {
                camera.GetComponent<CinemachineConfiner>().m_BoundingShape2D=(limits);
            }
            FadeOut();

           
        }
        // desplazar a other (player) a la posición target del
       
            /*
            if(Targetmap != null){
               // camera.GetComponent<MainCamera>().SetBounds(Targetmap);
            }
            else
            {
                gameObject.GetComponent<ChangeCamera>().ChangeCameras();
            }
            */
            
        
           
    }

    private void OnGUI()
    {
        if (!start)
            return;

        GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, alpha);

        Texture2D tex;
        tex = new Texture2D(1, 1);
        tex.SetPixel(0, 0, Color.black);
        tex.Apply();

        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), tex);

        if (isFadeIn)
        {
            alpha = Mathf.Lerp(alpha, 2.1f, fadeTime * Time.deltaTime);

        }
        else
        {
            alpha = Mathf.Lerp(alpha, -0.1f, fadeTime * Time.deltaTime);
            if (alpha < 0) start = false;
        }
    }

    private void FadeIn()
    {
        start = true;
        isFadeIn = true;
    }

    private void FadeOut()
    {
        isFadeIn = false;
    }





}
