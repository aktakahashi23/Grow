using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI; 

public class VolumeSettings : MonoBehaviour
{
    [SerializeField] private AudioMixer myMixer;
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider SFXSlider;

    private void Start() 
    {
        if (PlayerPrefs.HasKey("musicVolume")) //if player has set volume prefs load on start
        {
            LoadVolume(); 
        }
        else
        {
            SetMusicVolume(); //slider and audio mixer are compatible on start 
            SetSFXVolume();
        }
    }

    public void SetMusicVolume()
    {
        float volume = musicSlider.value;
        myMixer.SetFloat("music", Mathf.Log10(volume)*20); //music operates in logs, slider is linear 
        PlayerPrefs.SetFloat("musicVolume", volume); //playerprefs saves player settings even when game reloaded 
    }

    public void SetSFXVolume()
    {
        float volume = SFXSlider.value;
        myMixer.SetFloat("SFX", Mathf.Log10(volume) * 20); //music operates in logs, slider is linear 
        PlayerPrefs.SetFloat("SFXVolume", volume); //playerprefs saves player settings even when game reloaded 
    }

    private void LoadVolume()
    {
        musicSlider.value = PlayerPrefs.GetFloat("musicVolume");
        SFXSlider.value = PlayerPrefs.GetFloat("SFXVolume");
        SetMusicVolume();
        SetSFXVolume(); 
    }

}
