using NUnit.Framework.Internal;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.InputSystem;

// todo: build audio settings with sliders in Options tab after pausing
public class AudioSettings : MonoBehaviour
{
    [SerializeField] private AudioMixer mixer;
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider sfxSlider;

    void Awake()
    {  

        float musicVol = PlayerPrefs.GetFloat("MusicVolume", 0.5f);
        float sfxVol = PlayerPrefs.GetFloat("SFXVolume", 0.85f);
        musicSlider.value = musicVol;
        sfxSlider.value = sfxVol;
        SetMusicVolume(musicVol);
        SetSfxVolume(sfxVol);
    }

    void Update()
    {
        if (Keyboard.current.hKey.wasPressedThisFrame)
        {
            mixer.SetFloat("SFXVolume", -20f);
        }
        if (Keyboard.current.jKey.wasPressedThisFrame)
        {
            mixer.SetFloat("SFXVolume", 0f);
        }
        if (Keyboard.current.nKey.wasPressedThisFrame)
        {
            mixer.SetFloat("MusicVolume", -20f);
        }
        if (Keyboard.current.mKey.wasPressedThisFrame)
        {
            mixer.SetFloat("MusicVolume", 0f);
        }
    }

    public void SetSfxVolume(float volume)
    {
        float dB = Mathf.Log10(volume) * 20f;
        mixer.SetFloat("SFXVolume", dB);
        PlayerPrefs.SetFloat("SFXVolume", volume);
    }

    public void SetMusicVolume(float volume)
    {
        float dB = Mathf.Log10(volume) * 20f;
        mixer.SetFloat("MusicVolume", dB);
        PlayerPrefs.SetFloat("MusicVolume", volume);
    }
}
