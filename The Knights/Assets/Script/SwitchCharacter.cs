using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchCharacter : MonoBehaviour
{
    public GameObject char1, char2, char3;
    // Start is called before the first frame update
    void Start()
    {
        char1.gameObject.SetActive(true);
        char2.gameObject.SetActive(false);
        char3.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1)) 
        {
            char1.gameObject.SetActive(true);
            char2.gameObject.SetActive(false);
            char3.gameObject.SetActive(false);
             
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            char1.gameObject.SetActive(false);
            char2.gameObject.SetActive(true);
            char3.gameObject.SetActive(false);
        }
        if(Input.GetKeyDown(KeyCode.Alpha3))
        {
            char1.gameObject.SetActive(false);
            char2.gameObject.SetActive(false);
            char3.gameObject.SetActive(true);
        }
    }
}
