using UnityEngine;
using System;

public class BeatDetector : MonoBehaviour {
    [Header("Utility")]
    public static BeatDetector instance;
    public AudioSource aus;
    public AudioSource metronome;

    [Header("Metronome")]
    public float bpm = 60; // Song's BPM
    public float songPosition; // Determines the current position in the song.
    public float dspSongTime; // Song's overall length.
    public float secPerBeat; // How many seconds per beat (BPM translated).
    public int songPositionInBeats; // Position in song based on BPM.
    public int prevPos; // Keep track of previous position in beats to determine if on a new beat. 
    

    [Header("Beat Determiner")]
    public bool onBeat; // True on frames that are in rhythm.
        
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
    
    void Update() {
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
