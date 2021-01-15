using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGame : MonoBehaviour
{
    private bool gameRunning = true;
    [SerializeField] private GameObject canvasMenu;
    void Start()
    {
        canvasMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ChangeGameRuningState();
        }
    }

    public void ChangeGameRuningState()
    {
        gameRunning = !gameRunning;

        if (gameRunning)
        {
            Time.timeScale = 1f;
            canvasMenu.SetActive(false);

        }
        else
        {
            Time.timeScale = 0f;
            canvasMenu.SetActive(true);

        }
    }

    public bool IsGameRunning()
    {
        return gameRunning;
    }
}
