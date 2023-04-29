using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;


// This is a test script to show how something can be mapped to tempo--it can be deleted. 
public class TempoTest : MonoBehaviour {

    public Volume v;

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
