using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour {

    [SerializeField] private List<GameObject> waves;
    [SerializeField] private int currentWave;

    void Start() {
        foreach (Transform child in transform) {
            child.gameObject.SetActive(false); // Disable wave.

            waves.Add(child.gameObject); // Add wave to list.
        }
        waves[0].SetActive(true);
        currentWave = 0;
    }

    public void NextWave() {
        currentWave++;
        if (currentWave <= waves.Count) {
            waves[currentWave].SetActive(true);
        } else {
            Debug.Log("Level Complete");
        }
    }
   
}
