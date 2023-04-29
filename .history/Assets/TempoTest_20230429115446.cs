using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using System;

// This is a test script to show how something can be mapped to tempo--it can be deleted. 
public class TempoTest : MonoBehaviour {

    BeatDetector beatDetector = new BeatDetector();
    TempoResponse tempoResponse = new TempoResponse();

    public Volume v;

    void Start() {
        beatDetector.BeatDetected += tempoResponse.OnBeatDetected;
        v = GetComponent<Volume>();
    }
    void Update() {
        if (v.weight > 0) {
            v.weight -= 0.002f;
        } else {
            v.weight = 0;
        }        
    }
}

public class TempoResponse {
    public void OnBeatDetected(object source, EventArgs e) {
        Debug.Log("heard");
    }
}
