using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class OptionMenuController : MonoBehaviour
{
    // Mixer property
    public AudioMixer audioMixer;
    [SerializeField]Slider slider;
    [SerializeField]Toggle isFullScreenToggle;
    // Resolution
    public Dropdown resolutionDropdown;
    Resolution[] resolutions;
    GameSetting setting = new GameSetting(100, true, 0);

    public void Start()
    {
        resolutions = Screen.resolutions;
        resolutionDropdown.ClearOptions();


        List<string> options = new List<string>();

        int currentResoIndex = 0;
        for (int i = 0; i< resolutions.Length; i++) 
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);

            if (resolutions[i].width == Screen.currentResolution.width && 
                resolutions[i].height == Screen.currentResolution.height)
            {
                currentResoIndex = i;
            }
        }
        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResoIndex;
        resolutionDropdown.RefreshShownValue();
        setting = MyGameManager.Instance.LoadGameSetting();
        if (MyGameManager.Instance.LoadGameSetting() != null)
        {
            ChangeVolume(setting.volume);
            SetFullScreen(setting.isFullScreen);
            SetResolution(setting.resolutionIndex);
            resolutionDropdown.value = setting.resolutionIndex;
            resolutionDropdown.RefreshShownValue();
            slider.value = setting.volume;
            isFullScreenToggle.isOn = setting.isFullScreen;
        }

    }
    // Change volume using mixer
    public void ChangeVolume(float volume)
    {
        audioMixer.SetFloat("Volume", volume);
        setting.volume = volume;
    }
    // Set full screen
    public void SetFullScreen(bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
        setting.isFullScreen = isFullScreen;
    }

    // Set Resolution
    public void SetResolution(int index)
    {
        Resolution resolution = resolutions[index];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
        setting.resolutionIndex = index;
    }
    // Save Game Setting
    public void SaveGameSetting()
    {
        MyGameManager.Instance.SaveGameSetting(setting.volume, setting.isFullScreen, setting.resolutionIndex);
    }
}
