using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
public class VolumeSaveController : MonoBehaviour
{
    [SerializeField] private Slider volumeSlider;
    [SerializeField] AudioMixer audioMixer;
    private void Start()
    {
        loadValue();
    }
    public void SaveVolumeButton()
    {
        float volumeValue = volumeSlider.value;
        PlayerPrefs.SetFloat("VolumeValue", volumeValue);
        loadValue();
    }
    void loadValue()
    {
        float volumeValue = PlayerPrefs.GetFloat("VolumeValue");
        volumeSlider.value = volumeValue;
        audioMixer.SetFloat("Volume", volumeValue);
    }
}
