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
        musicVolumeSlider.value = GameManager.instance.musicVolume;
        sfxVolumeSlider.value = GameManager.instance.sfxVolume;
        mouseDashToggle.isOn = GameManager.instance.mouseDash;
    }

    public void UpdateMusic() {
        GameManager.instance.musicVolume = musicVolumeSlider.value;
        GameManager.instance.UpdateVolume();
    }

    public void UpdateSFX() {
        GameManager.instance.sfxVolume = sfxVolumeSlider.value;
        GameManager.instance.UpdateVolume();
    }

    public void UpdateMouseDash() {
        GameManager.instance.mouseDash = mouseDashToggle.isOn;
    }

}
