using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class OptionMenuController : MonoBehaviour
{
    // Mixer property
    public AudioMixer audioMixer;
    // Change volume using mixer
    public void ChangeVolume(float volume)
    {
        audioMixer.SetFloat("Volume", volume);
    }
    public void SetFullScreen(bool isFullScreen)
    {
         Screen.fullScreen = isFullScreen;
    }
}
