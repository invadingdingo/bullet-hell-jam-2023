using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Settings : MonoBehaviour {

    public static Settings instance;

    public AudioMixer mx;

    [Header("Volume")]
    [Range(-20, 0)]
    public float musicVolume = -10f;
    [Range(-20, 0)]
    public float sfxVolume = -10f;

    [Header("Gameplay")]
    public bool mouseDash = false;

    void Awake() {
        if (instance != null && instance != this) { 
            Destroy(this); 
        } else { 
            instance = this; 
        } 
    }

    void Update() {
        UpdateVolume();
    }

    public void UpdateVolume() {
        mx.SetFloat("Music", musicVolume);
        mx.SetFloat("SFX", sfxVolume);
    }

}
