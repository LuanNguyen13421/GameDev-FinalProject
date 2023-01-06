using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMenuControl : MonoBehaviour
{
    public GameObject StartMenu;
    public GameObject OptionMenu;
    public GameObject StartGameMenu;
    public void PlayGameButton()
    {
        StartMenu.SetActive(false);
        StartGameMenu.SetActive(true);
    }
    public void OptionMenuButton()
    {
        OptionMenu.SetActive(true);
        StartMenu.SetActive(false);
    }
    public void QuitGameButton()
    {
        Application.Quit();
    }
    public void BackToStartMenuButton()
    {
        StartMenu.SetActive(true);
        StartGameMenu.SetActive(false);
        OptionMenu.SetActive(false);
    }
}
