using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadSettingFileSave : MonoBehaviour
{
    [SerializeField] OptionMenuController option;
    // Start is called before the first frame update
    void Start()
    {
        option.Start();
    }

}
