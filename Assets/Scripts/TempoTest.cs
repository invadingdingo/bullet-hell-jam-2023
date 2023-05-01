using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using System;

// This is a test script to show how something can be mapped to tempo--it can be deleted. 
public class TempoTest : MonoBehaviour {
    private Volume v;

    void Start() {
        // Subscribe this object's OnBeat to the OnBeatEvent delegate 
        // held in the BeatCounter singleton.
        BeatCounter.instance.AddListener(OnBeat);

        v = GetComponent<Volume>();
    }

    void Update() {
        if (v.weight > 0f)
            v.weight -= 0.002f;
        else 
            v.weight = 0f;
    }

    void OnDestroy() {
        BeatCounter.instance.RemoveListener(OnBeat);
    }

    // This will be called whenever the event is triggered.
    void OnBeat() {
        v.weight = 1f;     
    }
}
