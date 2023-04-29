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
    public float songPosition, dspSongTime, songPositionInBeats, secPerBeat;

    void Start() {
        //Load the AudioSource attached to the Conductor GameObject
        aus = GetComponent<AudioSource>();

        //Calculate the number of seconds in each beat
        secPerBeat = 60f / bpm;

        //Record the time when the music starts
        dspSongTime = (float)AudioSettings.dspTime;

        //Start the music
        aus.Play();
    }
    
    void Update() {

        songPosition = (float)(AudioSettings.dspTime - dspSongTime);

        songPositionInBeats = songPosition / secPerBeat;

    }
}
