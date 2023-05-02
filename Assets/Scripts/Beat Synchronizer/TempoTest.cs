using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;


// This is a test script to show how something can be mapped to tempo--it can be deleted. 
public class TempoTest : MonoBehaviour {
    private Volume v;

    void Start() {
        // Subscribe this object's OnBeat to the OnBeatEvent delegate 
        // held in the BeatCounter singleton.
        BeatCounter.instance.AddListener(OnBeat);

        v = GetComponent<Volume>();
    }
    void OnDestroy() {
        BeatCounter.instance.RemoveListener(OnBeat);
    }

    // This will be called whenever the event is triggered.
    void OnBeat() {
        Tween.Animate(this, .01f, 0.1f, 0.2f, Tween.EaseIn, s => {
            v.weight = s;
        });  
    }
}
