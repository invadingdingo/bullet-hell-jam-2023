using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class TempoTest : MonoBehaviour {

    public Volume v;

    // Update is called once per frame
    void Update() {

        if (BeatDetector.instance.onBeat) {
            v.weight = 1;
        } else if (v.weight > 0) {
            v.weight -= 0.001f;
        } else {
            v.weight = 0;
        }        
    }
}
