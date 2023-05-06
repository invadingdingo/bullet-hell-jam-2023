using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    public static GameManager instance;
    public AudioMixer mx;
    public SfxPlayer SfxPlayerPrefab;

    [Header("Volume")]
    [Range(-20, 0)]
    public float musicVolume = -10f;
    [Range(-20, 0)]
    public float sfxVolume = -10f;

    [Header("Gameplay")]
    public bool mouseDash = false;
    public int enemyCount = 0;
    public List<GameObject> levels;

    void Awake() {
        if (instance != null && instance != this) { 
            Destroy(this); 
        } else { 
            instance = this; 
            DontDestroyOnLoad(instance.gameObject);
        } 
    }

    public void UpdateVolume() {
        mx.SetFloat("Music", musicVolume);
        mx.SetFloat("SFX", sfxVolume);
    }

    public void Play() {
        SceneManager.LoadScene("Levels");
    }

    public void MainMenu() {
        SceneManager.LoadScene("Main Menu");
        ResetValues();
    }

    public void GameOver() {
        Time.timeScale = 0f;
        FindObjectOfType<GameOver>().gameObject.transform.GetChild(0).gameObject.SetActive(true);
    }

    public void Retry() {
        SceneManager.LoadScene("Levels");
        ResetValues();
    }

    public void ResetValues() {
        Time.timeScale = 1f;
        enemyCount = 0;
    }

    public void LevelComplete() {

    }

    public void PlaySfx(AudioClip clip) {
        SfxPlayer sfx = Instantiate(SfxPlayerPrefab);
        sfx.Play(clip);
    }
}
