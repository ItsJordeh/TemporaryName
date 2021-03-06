using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using TMPro;
public class OptionsMenu : MonoBehaviour{
    Resolution[] resolutions;

    public TMP_Dropdown resolutionsDropdown;

    //on start of game, clear any data in resolution dropdown and replace with resolution options that are available.
    void Start () {
        resolutions = Screen.resolutions;

        resolutionsDropdown.ClearOptions();

        List<string> options = new List<string> ();
        int currentResolutionIndex = 0;
        for (int i = 0; i < resolutions.Length; i++) {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);
            if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height) {
                currentResolutionIndex = i;
            }
        }
        resolutionsDropdown.AddOptions(options);
        resolutionsDropdown.value = currentResolutionIndex;
        resolutionsDropdown.RefreshShownValue();
    }

    public void SetResolution (int resolutionIndex) {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }
    //set the volume slider to change the audio mixer, -80, 100 min max
    public AudioMixer audioMixer;
    public void SetVolume (float volume) {

        audioMixer.SetFloat("MenuVolume", volume);

    }

//change the quality of the game, defualt values 0-6
    public void SetQuality ( int qualityIndex) {

        QualitySettings.SetQualityLevel(qualityIndex);
    }

//Toggle fullscreen
    public  void SetFullscreen (bool isFullscreen) {

        Screen.fullScreen = isFullscreen;
    }
}
