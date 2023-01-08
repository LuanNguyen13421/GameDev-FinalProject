using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterPoint : MonoBehaviour
{
    [SerializeField] PauseMenu menu;
    void OnTriggerEnter2D(Collider2D other)
    {
        Player controller = other.GetComponent<Player>();
        if (controller != null)
        {
            menu.ShowWinGame();
        }
    }
}
