using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public static GameManager instance;

    public AudioMixer mx;

    [Header("Volume")]
    [Range(-20, 0)]
    public float musicVolume = -10f;
    [Range(-20, 0)]
    public float sfxVolume = -10f;

    [Header("Gameplay")]
    public bool mouseDash = false;

    public int enemyCount = 0;

    void Awake() {
        if (instance != null && instance != this) { 
            Destroy(this); 
        } else { 
            instance = this; 
            DontDestroyOnLoad(instance);
        } 
    }

    public void UpdateVolume() {
        mx.SetFloat("Music", musicVolume);
        mx.SetFloat("SFX", sfxVolume);
    }

    public List<GameObject> levels;

    public void LevelComplete() {

    }

    public void Play() {
        SceneManager.LoadScene("Levels");
    }

}
