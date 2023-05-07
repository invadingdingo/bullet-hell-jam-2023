using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    public static GameManager instance;
    public AudioMixer mx;
    public SfxPlayer SfxPlayerPrefab;

    public GameObject levelComplete;
    private bool transition = false; 

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
            DontDestroyOnLoad(instance.gameObject);
        } 
    }

    public void UpdateVolume() {
        mx.SetFloat("Music", musicVolume);
        mx.SetFloat("SFX", sfxVolume);
    }

    public void Play() {
        LoadScene(1);
    }

    public void MainMenu() {
        LoadScene(0);
        ResetValues();
    }

    public void GameOver() {
        mx.SetFloat("LowPass", 22000); // Fix audio.
        //Time.timeScale = 0f;
        FindObjectOfType<GameOver>().gameObject.transform.GetChild(0).gameObject.SetActive(true);
        Destroy(FindObjectOfType<PlayerHealth>().gameObject);
    }

    public void Retry() {
        LoadScene(SceneManager.GetActiveScene().buildIndex);
        ResetValues();
    }

    public void ResetValues() {
        Time.timeScale = 1f;
        enemyCount = 0;
    }

    public void LevelComplete() {
        if (!transition)
            StartCoroutine(LevelCompleteSequence());
    }

    IEnumerator LevelCompleteSequence() {
        transition = true;
        yield return new WaitForSeconds(1f);
        Instantiate(levelComplete, new Vector3(0, 0, 0), Quaternion.identity);
        yield return new WaitForSeconds(2f);
        transition = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        
    }
    public void PlaySfx(AudioClip clip) {
        SfxPlayer sfx = Instantiate(SfxPlayerPrefab);
        sfx.Play(clip);
    }
    

    public void LoadScene(int sceneId) {
        StartCoroutine(LoadSceneAsync(sceneId));
    }

    IEnumerator LoadSceneAsync(int sceneId) {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneId);

        while(!operation.isDone) {
            yield return null;
        }
    }
}
