using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEntrance : MonoBehaviour {
    [SerializeField] private List<GameObject> enemies;
    [SerializeField] private List<GameObject> spawnVisuals;
    [SerializeField] private GameObject spawnVisualPrefab;
    [SerializeField] private int nextSpawn;
    [SerializeField] private int enemyCount = 0;
    [SerializeField] private int spawnsRemaining = 0;
    [SerializeField] private int beatCount = 0;

    void Awake() {
        BeatManager.instance.AddQuarter(Spawn);
    }
    void OnEnable() {
        foreach (Transform child in transform) {
            child.gameObject.SetActive(false); // Disable enemy.

            GameObject spawnVisual = Instantiate(spawnVisualPrefab); // Spawn visual prefab.
            spawnVisual.transform.position = child.transform.position;

            enemies.Add(child.gameObject); // Add both enemy and visual to respective lists.
            spawnVisuals.Add(spawnVisual);
        }

        spawnsRemaining = enemies.Count;
    }

    void Update() {

        if (transform.childCount < enemyCount) {
            enemyCount = transform.childCount;
            GameManager.instance.enemyCount = enemyCount;
        }

        if (spawnsRemaining == 0 && enemyCount == 0) {
            Destroy(this.gameObject);
        }

    }

    void Spawn() {
        beatCount++;
        if (beatCount >= nextSpawn && spawnsRemaining != 0) { // If there are still enemies to spawn...
            enemies[enemyCount].SetActive(true);
            Destroy(spawnVisuals[enemyCount]);
            enemyCount++;
            GameManager.instance.enemyCount = enemyCount;
            beatCount = 0;
            spawnsRemaining -= 1;
        }

        if (spawnsRemaining == 0) {
            BeatManager.instance.RemoveQuarter(Spawn);
        }
    }
}
