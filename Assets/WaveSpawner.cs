using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour {
    public int BeatsUntilSpawn = 5;
    public GameObject SpawnVisualPrefab;

    private List<GameObject> waves;
    private List<GameObject> spawnVisuals;
    private int currentWave;
    private int beatCount;

    void Awake() {
        BeatManager.instance.AddQuarter(Spawn);

        waves = new List<GameObject>();
        spawnVisuals = new List<GameObject>();

        foreach (Transform child in transform) {
            waves.Add(child.gameObject);
            child.gameObject.SetActive(false);
        }
        StartWave(0);
    }

    void StartWave(int i) {
        currentWave = i;
        GameObject wave = waves[i];

        foreach (Transform child in wave.transform) {
            child.gameObject.SetActive(false);

            GameObject spawnVisual = Instantiate(SpawnVisualPrefab, child.transform.position, Quaternion.identity);
            spawnVisuals.Add(spawnVisual);
        }

        wave.SetActive(true);

        beatCount = BeatsUntilSpawn;
    }

    void Spawn() {
        GameObject wave = waves[currentWave];

        beatCount--;
        if (beatCount == 0) {
            foreach (GameObject child in spawnVisuals) {
                Destroy(child);
            }
            spawnVisuals.Clear();

            foreach (Transform child in wave.transform) {
                child.gameObject.SetActive(true);
            }
        }

        if (wave.transform.childCount == 0) {
            if (currentWave + 1 < waves.Count) {
                StartWave(currentWave + 1);
            } else {
                Debug.Log("Level Complete");
            }
        }
    }
}
