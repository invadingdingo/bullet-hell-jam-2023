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
    public Toggle difficultyToggle;

    public AudioClip play;
    public bool inRoutine = false;

    void Start() {
        musicVolumeSlider.value = GameManager.instance.musicVolume;
        sfxVolumeSlider.value = GameManager.instance.sfxVolume;
        mouseDashToggle.isOn = GameManager.instance.mouseDash;
        difficultyToggle.isOn = GameManager.instance.easyMode;
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

    public void UpdateDifficulty() {
        GameManager.instance.easyMode = difficultyToggle.isOn;
    }

    public void Play() {
        if (!inRoutine)
            StartCoroutine(PlayAudio());
    }

    IEnumerator PlayAudio() {
        inRoutine = true;
        GameManager.instance.PlaySfx(play);
        yield return new WaitForSeconds(play.length);
        GameManager.instance.Play();
        inRoutine = false;
    }

}
