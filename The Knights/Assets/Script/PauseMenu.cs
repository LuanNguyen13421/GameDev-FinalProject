using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Android;

public class PauseMenu : MonoBehaviour
{
    public static bool isPause = false;
    public GameObject pauseMenu;
    public GameObject settingMenu;
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)) 
        { 
            if(isPause)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }
    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isPause = false;
    }
    void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isPause= true;

    }
    public void Setting()
    {
        settingMenu.SetActive(true);
        pauseMenu.SetActive(false);
        isPause = true;
    }
    public void backToPauseMenu()
    {
        settingMenu.SetActive(false);
        pauseMenu.SetActive(true);
    }
}
