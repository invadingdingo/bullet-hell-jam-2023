using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour {

    [Header("Volume")]
    public Slider musicVolumeSlider;
    public Slider sfxVolumeSlider;

    [Header("Gameplay")]
    public Toggle mouseDashToggle;
    void OnEnable() {
        musicVolumeSlider.value = Settings.instance.musicVolume;
        sfxVolumeSlider.value = Settings.instance.sfxVolume;
        mouseDashToggle.isOn = Settings.instance.mouseDash;
    }

    public void UpdateMusic() {
        Settings.instance.musicVolume = musicVolumeSlider.value;
        Settings.instance.UpdateVolume();
    }

    public void UpdateSFX() {
        Settings.instance.sfxVolume = sfxVolumeSlider.value;
        Settings.instance.UpdateVolume();
    }

    public void UpdateMouseDash() {
        Settings.instance.mouseDash = mouseDashToggle.isOn;
    }

}
