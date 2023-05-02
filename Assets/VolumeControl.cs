using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeControl : MonoBehaviour {
    [Range(0, 1)]
    public float volume = 0.5f;

    void Update() {
        AudioListener.volume = volume;
    }
}
