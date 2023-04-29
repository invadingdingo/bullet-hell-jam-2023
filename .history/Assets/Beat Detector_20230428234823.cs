using UnityEngine;

public class BeatDetector : MonoBehaviour {
    public float bpm = 60;
    public AudioClip beat;
    
    void Start() {
        timeLastBeat = Time.time;
    }
    
    void Update() {
        float deltaTime = Time.deltaTime;
        bpm = 60f / deltaTime;
        timeLastBeat += deltaTime;
    }
}
