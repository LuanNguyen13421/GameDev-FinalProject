using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AreEnemiesDead : MonoBehaviour
{
    
    [SerializeField] PauseMenu menu;
    List<GameObject> listOfEnemies = new List<GameObject>();
    bool isWin = false;
    private void Start()
    {
        listOfEnemies.AddRange(GameObject.FindGameObjectsWithTag("Enemy"));
        Debug.Log("Enemy Count: " + listOfEnemies.Count);
    }
    private void Update()
    {
        if(areEnemysDead() && isWin == false)
        {
            isWin = true;
            menu.ShowWinGame();
        }
    }

    public void KilledEnemy(GameObject enemy)
    {
        if (listOfEnemies.Contains(enemy))
        {
            listOfEnemies.Remove(enemy);
        }
    }

    public bool areEnemysDead()
    {
        if (listOfEnemies.Count <= 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
