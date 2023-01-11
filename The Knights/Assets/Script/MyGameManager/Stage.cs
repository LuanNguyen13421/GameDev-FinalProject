using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Stage : MonoBehaviour
{
    [SerializeField]Text text;
    private void Start()
    {
        text.text = text.text + SceneManager.GetActiveScene().buildIndex;
    }
}
