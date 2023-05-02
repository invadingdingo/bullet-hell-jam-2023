using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Settings : MonoBehaviour {

    public static Settings instance;

    public AudioMixer mx;

    [Header("Volume")]
    [Range(-80, 0)]
    public float musicVolume = 0.5f;
    [Range(-80, 0)]
    public float sfxVolume = 0.5f;

    [Header("Gameplay")]
    public bool mouseDash = false;

    void Awake() {
        instance = this;
    }

    void Update() {
        UpdateVolume();
    }

    public void UpdateVolume() {
        mx.SetFloat("Music", musicVolume);
        //mixer.SetFloat("SFX", sfxVolume);
    }

}
