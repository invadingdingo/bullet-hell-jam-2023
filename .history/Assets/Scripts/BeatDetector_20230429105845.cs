using UnityEngine;

public class BeatDetector : MonoBehaviour {
    public static BeatDetector instance;
    public float bpm = 60;
    public AudioClip beat;
    public AudioSource aus;

    private float currentTime;
    public bool onBeat;
    public float beatCount;

    /////
    float songPosition, dspSongTime, songPositionInBeats, secPerBeat;


    // When starting, bpm becomes 60 (seconds in a minute) / bpm (how many beats should happen within 60s)
    void Start() {
        bpm = 60 / bpm;
        instance = this;
        currentTime = 0;
    }
    

    // Initially, current time reset after each beat, but this caused tempo drift over time. 
    // Instead, keeping total current time gives the tempo an absolute reference,
    // So if one beat is off a little, it won't throw the rest of them off after. 

    // onBeat can be accessed from any script using BeatDetector.instance.onBeat. Look in the MusicControl script for an example. 
    void Update() {

        songPosition = (float)(AudioSettings.dspTime - dspSongTime);

        songPositionInBeats = songPosition / secPerBeat;

        /*
        if (currentTime >= (bpm * beatCount + bpm) - 0.001f) {
            aus.PlayOneShot(beat);
            beatCount++;
            onBeat = true;
        } else {
            onBeat = false;
        }

        currentTime += Time.deltaTime;
        */

    }
}
