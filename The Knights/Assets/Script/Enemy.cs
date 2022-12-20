using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float health = 3f;

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            Destroy();
        }    
    }

    private void Destroy()
    {
        GameObject.Destroy(gameObject);
    }

    public void ModifyHealth(float amount)
    {
        health += amount;
    }
}
