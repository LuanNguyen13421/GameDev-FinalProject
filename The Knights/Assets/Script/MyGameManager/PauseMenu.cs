using Newtonsoft.Json.Bson;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Android;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool isPause = false;
    public GameObject pauseMenu;
    public GameObject player;
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
    public void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isPause= true;

    }
    public void QuitGamePlay()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1f;
        isPause = false;
    }
    public void SaveGame()
    {
        MyGameManager.Instance.SaveGame(player);
    }
}
