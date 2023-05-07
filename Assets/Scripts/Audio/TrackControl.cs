using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackControl : MonoBehaviour {

    public AudioSource[] sources;
    public bool[] playing;

    [Range(0, 5)]
    public int waveCount;
    private int prevWaveCount;
    public float maxVolume;
    public float fadeTime;

    void Start() {
        for(int x = 0; x < sources.Length; x++)
            playing[x] = false;
    }

    void Update() {
        waveCount = GameManager.instance.waveCount;
        if (waveCount > prevWaveCount && waveCount <= sources.Length) {
            for(int x = 0; x < waveCount; x++) {
                if (!playing[x]) {
                    StartCoroutine(RaiseVolume(sources[x]));
                    playing[x] = true;
                }
            }
        }

        if (waveCount < prevWaveCount && waveCount >= 0) {
            for(int x = sources.Length - 1; x >= waveCount; x--) {
                if (playing[x]) {
                    StartCoroutine(DecreaseVolume(sources[x]));
                    playing[x] = false;
                }
            }
        }

        prevWaveCount = waveCount;
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
