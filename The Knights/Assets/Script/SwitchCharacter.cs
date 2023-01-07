using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchCharacter : MonoBehaviour
{
    public Player char1, char2, char3;
    [SerializeField] PauseMenu menu;
    // Start is called before the first frame update
    void Start()
    {
        char1.gameObject.SetActive(true);
        char2.gameObject.SetActive(false);
        char3.gameObject.SetActive(false);
    }
    // Flag to check char is dead or alive (avoid recall many times)
    bool checkChar1 = false;
    bool checkChar2 = false;
    bool checkChar3 = false;

    // Flag to check "Is game lose?" (avoid recall many times)
    bool isLose = false;

    // Update is called once per frame
    void Update()
    {   
        if (checkChar1 && checkChar2 && checkChar3 && isLose == false) 
        {
            isLose= true;
            menu.ShowLoseGame();
        }
        if(char1.isDeath && checkChar1 == false)
        {
            checkChar1 = true;
            char1.gameObject.SetActive(false);
            if (char2.isDeath) 
            {
                if (char3.isDeath == false)
                    PlayChar3();
            }
            else { PlayChar2(); }
        }
        else if (char2.isDeath  && checkChar2 == false)
        {
            checkChar2 = true;
            char2.gameObject.SetActive(false);
            if (char1.isDeath)
            {
                if (char3.isDeath == false)
                    PlayChar3();
            }
            else { PlayChar1(); }
        }
        else if (char3.isDeath && checkChar3 == false)
        {
            checkChar3 = true;
            char3.gameObject.SetActive(false);
            if (char1.isDeath)
            {
                if (char2.isDeath == false)
                    PlayChar2();
            }
            else { PlayChar1(); }
        }
        if (Input.GetKeyDown(KeyCode.Alpha1) && char1.isDeath == false) 
        {
            PlayChar1();
        }
        if (Input.GetKeyDown(KeyCode.Alpha2) && char2.isDeath == false)
        {
            PlayChar2();
        }
        if(Input.GetKeyDown(KeyCode.Alpha3) && char3.isDeath == false)
        {
            PlayChar3();
        }
    }
    void PlayChar1()
    {
        char1.gameObject.SetActive(true);
        char2.gameObject.SetActive(false);
        char3.gameObject.SetActive(false);
    }
    void PlayChar2()
    {
        char1.gameObject.SetActive(false);
        char2.gameObject.SetActive(true);
        char3.gameObject.SetActive(false);
    }
    void PlayChar3()
    {
        char1.gameObject.SetActive(false);
        char2.gameObject.SetActive(false);
        char3.gameObject.SetActive(true);
    }
}
