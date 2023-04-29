using UnityEngine;

public class BeatDetector : MonoBehaviour {
    public static BeatDetector instance;
    public float bpm = 60;
    //public AudioClip beat;
    public AudioSource aus;

    private float currentTime;
    public bool onBeat;
    public float beatCount;

    /////
    public float songPosition, dspSongTime, secPerBeat;
    public int songPositionInBeats;
    public int prevPos;

    public AudioSource metronome;

    void Start() {

        instance = this;

        prevPos = 0;
        //Load the AudioSource attached to the Conductor GameObject
        aus = GetComponent<AudioSource>();

        //Calculate the number of seconds in each beat
        secPerBeat = 60f / bpm;

        //Record the time when the music starts
        dspSongTime = (float)AudioSettings.dspTime;

        //Start the music
        aus.Play();
    }
    
    void FixedUpdate() {
        if (songPositionInBeats > prevPos) {
            onBeat = true;
            prevPos = songPositionInBeats;
            metronome.Play();
        } else {
            onBeat = false;
        }

        songPosition = (float)(AudioSettings.dspTime - dspSongTime);

        songPositionInBeats = (int)(songPosition / secPerBeat);

        

    }
}
