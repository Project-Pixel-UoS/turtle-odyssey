using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SettingsMenu : MonoBehaviour
{
    /// <summary>
    /// Allow user to change volume of music and SFX using sliders.
    /// </summary>
    /// <remarks>
    /// Maintained by: Iva Koleva
    /// </remarks>

    public AudioMixer SoundVolume;
    public Slider VolumeSlider;
    public Slider SfxSlider;

    private void Start()
    {
        MusicVolumeSet();
        SfxVolumeSet();
    }

    public void MusicVolumeSet()
    {
        float Volume = VolumeSlider.value;
        SoundVolume.SetFloat("MusicVolume", Volume);
    }

    public void SfxVolumeSet()
    {
        float SfxVolume = SfxSlider.value;
        SoundVolume.SetFloat("SfxVolume", SfxVolume);
    }
}
