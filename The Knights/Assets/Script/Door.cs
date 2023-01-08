using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            transform.parent.gameObject.GetComponent<Room>().StartRoom();   
        }
    }

    public void Open()
    {
        gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
    }

    public void Close()
    {
        gameObject.GetComponent<BoxCollider2D>().isTrigger = false;
    }
}
