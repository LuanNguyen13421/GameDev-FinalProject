using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionCollectible : MonoBehaviour
{
    public float healthNumber = 1.0f;
    void OnTriggerEnter2D(Collider2D other)
    {
        Player controller = other.GetComponent<Player>();

        if (controller != null)
        {
            if (controller.health < controller.getMaxHealth())
            {
                controller.ModifyHealth(healthNumber);
                Destroy(gameObject);
            }
        }
    }
}
