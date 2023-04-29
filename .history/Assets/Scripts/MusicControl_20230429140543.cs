using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicControl : MonoBehaviour {
    bool playing = false;

    void Update() {

        // If the music isn't playing, wait until the tempo is synced, then play audio.
        if (!playing) {
            if(BeatDetector.instance.onBeat) {
                GetComponent<AudioSource>().Play();
                playing = true;
            }
        }
    }
}
