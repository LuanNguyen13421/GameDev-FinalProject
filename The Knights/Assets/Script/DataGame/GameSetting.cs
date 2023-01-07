using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class GameSetting
{
    public float volume;
    public bool isFullScreen;
    public int resolutionIndex;
    public GameSetting(float volume, bool isFullScreen, int resolutionIndex)
    {
        this.volume = volume;
        this.isFullScreen = isFullScreen;
        this.resolutionIndex = resolutionIndex;
    }
    public GameSetting() 
    {
        this.volume = 0.0f;
        this.isFullScreen = false;
        this.resolutionIndex = 0;
    }
}
