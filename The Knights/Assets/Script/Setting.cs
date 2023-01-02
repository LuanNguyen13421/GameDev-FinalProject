using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Setting : MonoBehaviour
{
    public Slider VolumeSlider;
    public void increaseVolume()
    {
        VolumeSlider.value = VolumeSlider.value + 1;
    }
    public void decreaseVolume()
    {
        VolumeSlider.value = VolumeSlider.value - 1;
    }
    public void back()
    {

    }
}
