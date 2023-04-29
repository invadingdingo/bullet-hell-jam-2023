using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicControl : MonoBehaviour {
    bool playing = false;

    // Update is called once per frame
    void Update() {
        if (!playing) {
            if BeatDetector.instance.onBeat {
                GetComponent<AudioSource>().Play();
            }
        }
    }
}
