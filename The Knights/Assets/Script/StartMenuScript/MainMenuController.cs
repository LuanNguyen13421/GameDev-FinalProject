using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    //Option menu property
    public GameObject optionMenu;
    public GameObject startGameMenu;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void StartGame()
    {
        startGameMenu.SetActive(true);
    }
    public void ShowOptionMenu()
    {
        optionMenu.SetActive(true);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void PauseGame()
    {
        MyGameManager.Instance.PauseGame();
    }
    public void ResumeGame()
    {
        MyGameManager.Instance.ResumeGame();
    }
}
