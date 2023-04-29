using UnityEngine;

public class BeatDetector : MonoBehaviour {
    public float bpm = 60;
    public AudioClip beat;
    public AudioSource aus;

    private float previousBeat;
    
    void Start() {
        previousBeat = Time.time;
    }
    
    void Update() {
        if (Time.time - previousBeat > 1 / bpm) {
            aus.Play();
        }
    }
}
