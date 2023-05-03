using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManageer : MonoBehaviour {

    [SerializeField] private List<GameObject> waves;

    void Start() {
        foreach (Transform child in transform) {
            child.gameObject.SetActive(false); // Disable wave.

            waves.Add(child.gameObject); // Add wave to list.
        }
        waves[0].SetActive(true);
    }

    void Update() {
        if (waves[0] == null) {
            waves.RemoveAt(0);
            waves[0].SetActive(true);
        }
    }
   
}
