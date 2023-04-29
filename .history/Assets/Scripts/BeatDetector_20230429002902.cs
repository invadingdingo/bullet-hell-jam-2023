using UnityEngine;

public class BeatDetector : MonoBehaviour {
    public static BeatDetector instance;
    public float bpm = 60;
    public AudioClip beat;
    public AudioSource aus;

    private float currentTime;
    public bool onBeat;
    public float beatCount;

    void Start() {
        bpm = 60 / bpm;
        instance = this;
        currentTime = 0;
    }
    
    void Update() {
        if ( (bpm * beatCount + bpm) -0.01f; >= currentTime || currentTime >= bpm * beatCount + bpm) {
            aus.PlayOneShot(beat);
            //currentTime = 0;
            beatCount++;
            onBeat = true;
        } else {
            onBeat = false;
        }

        currentTime += Time.deltaTime;


    }
}
