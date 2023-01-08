using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField]GameObject enemyCount;
    float countTime;
    float timer = 1.5f;
    void Start()
    {
        countTime = timer;
    }
    private void Update()
    {
        // Delay enemy count
        countTime = countTime - Time.deltaTime;
        if (countTime < 0)
        {
            enemyCount.SetActive(true);
        }
    }

}
