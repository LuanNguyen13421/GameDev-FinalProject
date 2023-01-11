using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class StartGameMenuControl : MonoBehaviour
{
    public void NewGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        MyGameManager.Instance.SaveGame(0, 0, 0, SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void ContinueGame()
    {
        TheKnightData temp = MyGameManager.Instance.LoadSave();
        SceneManager.LoadScene(temp.getSceneIndex());
    }
}
