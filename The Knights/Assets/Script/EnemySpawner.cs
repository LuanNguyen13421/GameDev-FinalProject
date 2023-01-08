using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public float delay;
    public ParticleSystem spawnEffect;
    public void StartSpawnCount()
    {
        gameObject.SetActive(false);
        Invoke("Spawn", delay);
    }

    void Spawn()
    {
        var effect = Instantiate(spawnEffect, transform.position, transform.rotation, gameObject.transform);
        Destroy(effect, effect.main.duration);
        gameObject.SetActive(true);
        gameObject.GetComponent<Enemy>().SetAttack(true);
    }    
}
