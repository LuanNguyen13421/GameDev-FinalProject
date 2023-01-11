using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelText : MonoBehaviour
{
    [SerializeField] Text level;
    public void SetLevel(int i)
    {
        level.text = "Level: " + i.ToString();
    }
}
