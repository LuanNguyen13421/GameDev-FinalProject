using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
public class MyGameManager
{
    // Singleton
    private static MyGameManager _instance;
    public static MyGameManager Instance
    {
        get
        {
            if(_instance == null)
            {
                _instance = new MyGameManager();
            }
            return _instance;
        }
    }

    //Pause Game
    public void PauseGame()
    {
        Time.timeScale = 0.0f;
    }
    public void ResumeGame()
    {
        Time.timeScale = 1.0f;
    }
    public void SaveGame(float expChar1, float expChar2, float expChar3, int sceneIndex)
    {
        // Save Game
        string path = Path.Combine(Application.persistentDataPath, "player.hd");
        FileStream file = File.Create(path);
        TheKnightData data = new TheKnightData(expChar1, expChar2, expChar3, sceneIndex);
        // Create binary formatter
        BinaryFormatter formatter = new BinaryFormatter();
        formatter.Serialize(file, data);
        file.Close();
        Debug.Log("Game saved " + path);
    }
    public TheKnightData LoadSave()
    {
        string path = Path.Combine(Application.persistentDataPath, "player.hd");
        if(File.Exists(path))
        {
            FileStream file = File.Open(path, FileMode.Open);
            BinaryFormatter formatter = new BinaryFormatter();

            TheKnightData theKnightData = (TheKnightData)formatter.Deserialize(file);
            file.Close();
            Debug.Log("Game loaded" + path);
            return theKnightData;
        }
        return null;
    }
    public void SaveGameSetting(float volume, bool isFullScreen, int resolutionIndex)
    {
        // Save Game
        string path = Path.Combine(Application.persistentDataPath, "gameSetting.hd");
        FileStream file = File.Create(path);
        // Create setting data
        GameSetting setting = new GameSetting(volume, isFullScreen, resolutionIndex);
        // Create binary formatter
        BinaryFormatter formatter = new BinaryFormatter();
        formatter.Serialize(file, setting);
        file.Close();
        Debug.Log("Game's Setting saved " + path);
    }
    public GameSetting LoadGameSetting()
    {
        string path = Path.Combine(Application.persistentDataPath, "gameSetting.hd");
        if (File.Exists(path))
        {
            FileStream file = File.Open(path, FileMode.Open);
            BinaryFormatter formatter = new BinaryFormatter();

            GameSetting setting = (GameSetting)formatter.Deserialize(file);
            file.Close();
            Debug.Log("Game loaded" + path);
            return setting;
        }
        return null;
    }
}
