using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class PauseMenu : MonoBehaviour
{
    public static bool paused = false;
    public GameObject PauseMenueUI;
    public GameObject Text;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (paused)
                Resume();
            else
            {
                Pause();
            }
        }
        
        void Pause()
        {
            PauseMenueUI.SetActive(true);
            Text.SetActive(false);
            Cursor.lockState = CursorLockMode.Confined;
            //Time.timeScale = 0f;
            paused = true;
        }
    }
    public void Resume()
    {
        PauseMenueUI.SetActive(false);
        Text.SetActive(true);

        Cursor.lockState = CursorLockMode.Locked;
        //Time.timeScale = 1f;
        paused = false;
    }
    public void LoadMenu()
    {
        //Time.timeScale = 1f;

        SceneManager.LoadScene(0);
    }
    public void Quit()
    {
        Application.Quit();
    }
}

