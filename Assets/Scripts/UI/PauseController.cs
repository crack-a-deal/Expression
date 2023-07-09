using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseController : MonoBehaviour
{
    public static bool gameIsPaused=false;
    [SerializeField] private GameObject panel;
    [SerializeField] private GameObject settings;
    [SerializeField] private GameObject exit;
    [SerializeField] private GameObject info;

    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)) 
            if (!gameIsPaused)
            {
                Debug.Log("Pause");
                Pause();
            }
            else
            {
                Debug.Log("Resume");
                if (settings.gameObject.activeSelf)
                {
                    settings.gameObject.SetActive(false);
                    return;
                }
                if (exit.gameObject.activeSelf)
                {
                    exit.gameObject.SetActive(false);
                    return;
                }

                Resume();
            }
        if (Input.GetKeyDown(KeyCode.Tab) &&!gameIsPaused)
        {
            Debug.Log("INFO");
            info.SetActive(!info.activeSelf);
        }
    }

    public void Pause()
    {
        gameIsPaused = true;
        panel.SetActive(true);
        Time.timeScale = 0f;
    }
    public void Resume()
    {
        gameIsPaused = false;
        panel.SetActive(false);
        Time.timeScale = 1f;
    }
}