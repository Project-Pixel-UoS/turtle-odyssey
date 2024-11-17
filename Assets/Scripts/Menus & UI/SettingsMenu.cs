using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class SettingsMenu : MonoBehaviour
{
    /// <summary>
    /// Allow user to change volume of music and SFX using sliders.
    /// </summary>
    /// <remarks>
    /// Maintained by: Iva Koleva and Abdallah Khorma
    /// </remarks>

    public AudioMixer SoundVolume;
    public Slider VolumeSlider;
    public Slider SfxSlider;

    private void Start()
    {
        // MusicVolumeSet();
        float musicVolume, sfxVolume;
        SoundVolume.GetFloat("MusicVolume", out musicVolume);
        SoundVolume.GetFloat("SfxVolume", out sfxVolume);
        VolumeSlider.value = Mathf.Pow(10f, (musicVolume / 20.0f));
        SfxSlider.value = Mathf.Pow(10f, (sfxVolume/ 20.0f));
        // SfxVolumeSet();
    }

    public void MusicVolumeSet()
    {
        float Volume = Mathf.Log10(VolumeSlider.value) * 20;
        if (VolumeSlider.value == 0.0) {Volume = -80f;}
        SoundVolume.SetFloat("MusicVolume", Volume);
    }

    public void SfxVolumeSet()
    {
        float SfxVolume = Mathf.Log10(SfxSlider.value) * 20;
        if (SfxSlider.value == 0.0) {SfxVolume = -80f;}
        SoundVolume.SetFloat("SfxVolume", SfxVolume);
    }

    public void LoadLevel()
    {
        SceneManager.LoadScene(sceneName: "LevelSelection");
    }
}
