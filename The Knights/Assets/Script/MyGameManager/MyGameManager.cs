using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
public class MyGameManager
{
    // Is new game
    public static bool isNewGame = true;
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
    public void SaveGame(GameObject player)
    {
        // Save Game
        string path = Path.Combine(Application.persistentDataPath, "playerControllerTemp.hd");
        FileStream file = File.Create(path);
        // Create The Knight data
        PlayerController theKnightController = player.GetComponent<PlayerController>();
        Vector2 position;
        position.x = theKnightController.controllerPosX;
        position.y = theKnightController.controllerPosY;
        TheKnightData theKnightData = new TheKnightData(position);
        // Create binary formatter
        BinaryFormatter formatter = new BinaryFormatter();
        formatter.Serialize(file, theKnightData);
        file.Close();
        Debug.Log("Game saved " + path);
    }
    public Vector2 LoadPlayerPosition()
    {
        Vector2 position;
        position.x = 0.0f;
        position.y = 0.0f;
        string path = Path.Combine(Application.persistentDataPath, "playerControllerTemp.hd");
        if(File.Exists(path))
        {
            FileStream file = File.Open(path, FileMode.Open);
            BinaryFormatter formatter = new BinaryFormatter();

            TheKnightData theKnightData = (TheKnightData)formatter.Deserialize(file);
            file.Close();
            // Load data
            position.x = theKnightData.position[0];
            position.y = theKnightData.position[1];
            Debug.Log("Game loaded" + path);
        }
        return position;
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
