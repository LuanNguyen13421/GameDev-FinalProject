using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExperienceParticle : MonoBehaviour
{
    public float experienceNumber = 20.0f;
    void OnTriggerEnter2D(Collider2D other)
    {
        Player controller = other.GetComponent<Player>();
        if (controller != null)
        {
                controller.ModifyExp(experienceNumber);
                Destroy(gameObject);
        }
    }
}
