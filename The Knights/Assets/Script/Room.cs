using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    public List<Door> doorList;
    List<string> enemyList;

    bool isFinished = true;
    bool hasStarted = false;

    int enemyCount = 0;
    void Start()
    {
        var enemies = GetComponentsInChildren<Transform>();
        for (int i = 0; i < enemies.Length; i++)
        {
            if (enemies[i].transform.name.Contains("Enemy"))
            {
                enemies[i].gameObject.GetComponent<Renderer>().enabled = false;
                enemyCount++;
            }
        }

        if (enemies.Length > 0)
        {
            isFinished = false;
        }
    }

    public bool IsFinished()
    {
        return isFinished;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.childCount - doorList.Count == 0)
        {
            isFinished = true;
            EndRoom();
        }
    }

    public void StartRoom()
    {
        if(hasStarted)
        {
            return;
        }

        hasStarted = true;

        var enemies = GetComponentsInChildren<Transform>();
        for (int i = 0; i < enemies.Length; i++)
        {
            if (enemies[i].transform.name.Contains("Enemy"))
            {
                enemies[i].gameObject.SetActive(true);
                enemies[i].gameObject.GetComponent<Renderer>().enabled = true;
                enemies[i].gameObject.GetComponent<EnemySpawner>().StartSpawnCount();
            }
        }

        CloseDoor();
    }

    void OpenDoor()
    {
        for (int i = 0; i < doorList.Count; i++)
        {
            doorList[i].Open();
        }
    }

    void CloseDoor()
    {
        for (int i = 0; i < doorList.Count; i++)
        {
            doorList[i].Close();
        }
    }

    void EndRoom()
    {
        OpenDoor();
    }
}
