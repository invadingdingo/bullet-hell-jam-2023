using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SynchronizerData;

public class BeatManager : MonoBehaviour {
    public static BeatManager instance;
    public delegate void OnBeatEventHandler();
	public event OnBeatEventHandler OnQuarterBeatEvent;
    public event OnBeatEventHandler OnTripletBeatEvent;
    void Awake() {
        instance = this;
    }

    public void AddTriplet(OnBeatEventHandler listener) {
        OnTripletBeatEvent += listener;
    }

    public void RemoveTriplet(OnBeatEventHandler listener) {
        OnTripletBeatEvent -= listener;
    }
    
    public void AddQuarter(OnBeatEventHandler listener) {
        OnQuarterBeatEvent += listener;
    }

    public void RemoveQuarter(OnBeatEventHandler listener) {
        OnQuarterBeatEvent -= listener;
    }

    public void BeatEvent(BeatValue beat) {
        if (beat == BeatValue.QuarterBeat) {
            //Debug.Log("Beat");
            if (OnQuarterBeatEvent != null)
                OnQuarterBeatEvent();
        } else if (beat == BeatValue.Triplet) {
            if (OnTripletBeatEvent != null)
                OnTripletBeatEvent();
        }
    }
}
