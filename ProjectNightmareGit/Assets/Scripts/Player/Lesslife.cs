using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lesslife : MonoBehaviour
{
    [SerializeField]
    private GameObject target;
    [SerializeField]
    private int life = 12;
    [SerializeField]
    private SpriteLives spriteLives;

    private GameObject player;
    private Renderer playerRender;

    private Color ColorT;
    private Color ColorV;

    private bool golpeable=true;

    public void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerRender = player.GetComponent<Renderer>();
    

        spriteLives = GameObject.FindObjectOfType<SpriteLives>();

        ColorT = new Color(playerRender.material.color.r, playerRender.material.color.g, playerRender.material.color.b, 0);
        ColorV = new Color(playerRender.material.color.r, playerRender.material.color.g, playerRender.material.color.b, 1);
    }
    private void OnTriggerEnter2D(Collider2D collision){
        
        if(golpeable){
            if(collision.CompareTag("RockAttack"))
            {
                life -= 1;
                Debug.Log("me ha dado"+life);

                spriteLives.ChangeHearts(life);
                
                if (life <= 0){
                    Debug.Log("he muerto");
                    Destroy(target);    
                }

                    StartCoroutine(CambiarTransperencia());
            
            }
        }
    }

    public IEnumerator CambiarTransperencia()
    {
        golpeable = false;
        int i = 0;
        do
        {
            
            playerRender.material.color = ColorT;
            yield return new WaitForSeconds(0.1f);
            playerRender.material.color = ColorV;
            i++;
            yield return new WaitForSeconds(0.1f);
        } while (i < 5);
        golpeable = true;
    }


}
