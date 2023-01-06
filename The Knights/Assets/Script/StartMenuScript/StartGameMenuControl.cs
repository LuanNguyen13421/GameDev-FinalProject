using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class StartGameMenuControl : MonoBehaviour
{
    public void NewGame()
    {
        MyGameManager.isNewGame = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void ContinueGame()
    {
        MyGameManager.isNewGame = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
