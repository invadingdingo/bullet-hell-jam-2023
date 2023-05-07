using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSplash : MonoBehaviour {

    public bool displayed = true;
    public GameObject text;

    void Start() {
        BeatManager.instance.AddTriplet(OnBeat);
    }

    void OnBeat() {
        if (displayed)
            text.SetActive(true);
        else 
            text.SetActive(false);

        displayed = !displayed;
    }

}
