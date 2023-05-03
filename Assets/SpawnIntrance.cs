using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnIntrance : MonoBehaviour {
    [SerializeField] private List<GameObject> enemies;
    [SerializeField] private List<GameObject> spawnVisuals;
    [SerializeField] private GameObject spawnVisualPrefab;
    [SerializeField] private int nextSpawn;
    [SerializeField] private int enemyCount = 0;
    [SerializeField] private int beatCount = 0;

    void Awake() {
        BeatManager.instance.AddQuarter(Spawn);
    }
    void OnEnable() {
        foreach (Transform child in transform) {
            child.gameObject.SetActive(false); // Disable enemy.

            GameObject spawnVisual = Instantiate(spawnVisualPrefab); // Spawn visual prefab.
            spawnVisual.transform.position = child.transform.position;

            enemies.Add(child.gameObject); // Add both to respective lists.
            spawnVisuals.Add(spawnVisual);
        }
        // Start timer (tempo)
        // When timer finishes, reenable enemies
        // Destroy spawn vis
    }

    void Spawn() {
        beatCount++;
        if (beatCount >= nextSpawn && enemyCount < enemies.Count) {
            enemies[enemyCount].SetActive(true);
            Destroy(spawnVisuals[enemyCount]);
            enemyCount++;
            beatCount = 0;
        }
    }
}
