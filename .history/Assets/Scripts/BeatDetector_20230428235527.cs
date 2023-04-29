using UnityEngine;

public class BeatDetector : MonoBehaviour {
    public float bpm = 60;
    public AudioClip beat;
    public AudioSource aus;

    private float currentTime;
    
    void Start() {
        currentTime = 0;
    }
    
    void Update() {
        if (currentTime > 1) {
            aus.PlayOneShot(beat);
            currentTime = 0;
        }

        currentTime += Time.deltaTime;


    }
}
