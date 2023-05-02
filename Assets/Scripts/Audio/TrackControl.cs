using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackControl : MonoBehaviour {

    public AudioSource[] sources;
    public bool[] playing;

    [Range(0, 4)]
    public int enemyCount;
    private int prevEnemyCount;
    public float maxVolume;
    public float fadeTime;

    void Start() {
        for(int x = 0; x < sources.Length; x++)
            playing[x] = false;
    }

    public void AddEnemy() {
        if(enemyCount < sources.Length)
            enemyCount++;
    }

    public void RemoveEnemy() {
        if (enemyCount != 0)
            enemyCount--;
    }

    void Update() {
        if (enemyCount > prevEnemyCount && enemyCount <= sources.Length) {
            for(int x = 0; x < enemyCount; x++) {
                if (!playing[x]) {
                    StartCoroutine(RaiseVolume(sources[x]));
                    playing[x] = true;
                }
            }
        }

        if (enemyCount < prevEnemyCount && enemyCount >= 0) {
            for(int x = sources.Length - 1; x >= enemyCount; x--) {
                if (playing[x]) {
                    StartCoroutine(DecreaseVolume(sources[x]));
                    playing[x] = false;
                }
            }
        }

        prevEnemyCount = enemyCount;
    }

    IEnumerator RaiseVolume(AudioSource s) {
        float elapsedTime = 0;
        float currentVolme = s.volume;
        while (elapsedTime < fadeTime) {
            s.volume = Mathf.Lerp(currentVolme, maxVolume, (elapsedTime / fadeTime));
            elapsedTime += Time.deltaTime;
    
            yield return null;
        }

        yield return null;
    }

    IEnumerator DecreaseVolume(AudioSource s) {
        float elapsedTime = 0;
        float currentVolme = s.volume;
        while (elapsedTime < fadeTime) {
            s.volume = Mathf.Lerp(currentVolme, 0, (elapsedTime / fadeTime));
            elapsedTime += Time.deltaTime;
    
            yield return null;
        }

        yield return null;
    }
}
