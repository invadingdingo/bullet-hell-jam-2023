using UnityEngine;

public class BeatDetector : MonoBehaviour {
    public static BeatDetector instance;
    public float bpm = 60;
    public AudioClip beat;
    public AudioSource aus;

    private float currentTime;
    public bool onBeat;
    
    void Start() {
        instance = this;
        currentTime = 0;
    }
    
    void Update() {
        if (currentTime > 60f / bpm) {
            aus.PlayOneShot(beat);
            currentTime = 0;
            onBeat = true;
        } else {
            onBeat = false;
        }

        currentTime += Time.deltaTime;


    }
}
