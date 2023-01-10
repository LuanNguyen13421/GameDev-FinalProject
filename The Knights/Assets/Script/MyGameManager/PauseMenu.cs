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
    public Player player1;
    public Player player2;
    public Player player3;
    public GameObject LoseGameBanner;
    public GameObject WinGameBanner;
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
        Time.timeScale = 1.0f;
        isPause = false;
        SceneManager.LoadScene(0);
    }
    public void SaveGame()
    {
        MyGameManager.Instance.SaveGame(player1.getExp(), player2.getExp(), player3.getExp(), SceneManager.GetActiveScene().buildIndex);
    }
    public void ShowLoseGame()
    {
        LoseGameBanner.SetActive(true);
        Time.timeScale = 0f;
        isPause = true;
    }
    public void ShowWinGame()
    {
        WinGameBanner.SetActive(true);
        MyGameManager.Instance.SaveGame(player1.getExp(), player2.getExp(), player3.getExp(), SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 0f;
        isPause = true;
    }
    public void LoadNextScene()
    {
        Time.timeScale = 1.0f;
        isPause = false;
        if (SceneManager.GetActiveScene().buildIndex < SceneManager.sceneCountInBuildSettings - 1)
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        else SceneManager.LoadScene(0);
    }
}
