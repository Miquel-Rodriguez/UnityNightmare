using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ChangeTo1 : MonoBehaviour
{

    private bool start = false;
    private bool isFadeIn = false;
    private float alpha = 0;
    private float fadeTime = 0.5f;
    public void SceneSwitcher()
    {
        StartCoroutine(Switch());
    }

    private void Start()
    {
        StartCoroutine(GrowDawn());
    }

    private IEnumerator GrowDawn()
    {
        alpha = 1;
        FadeIn();
        yield return new WaitForSeconds(fadeTime);
        fadeTime = 0.5f;
        FadeOut();
    }

    private IEnumerator Switch()
    {
        FadeIn();
        yield return new WaitForSeconds(fadeTime + 1.5f);
        SceneManager.LoadScene(1);
        FadeOut();
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

    
