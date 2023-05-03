using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawn : MonoBehaviour {
    public SingleBulletPattern BulletPattern;
    public GameObject BulletPrefab;
    public float BulletSpawnDelay = 0.2f;

    private float time;

    void Start() {
        time = BulletSpawnDelay;
    }

    void Update() {
        // spawn
        if (time > 0) {
            time -= Time.deltaTime;
        } else {
            time = BulletSpawnDelay;

            // spawn bullets
            SingleBulletPattern pattern = Instantiate(BulletPattern, transform.position, Quaternion.identity);

            pattern.Spawn(
                prefab: BulletPrefab,
                direction: Random.insideUnitCircle.normalized,
                speed: 20f
            );
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        Destroy(gameObject);
    }
}
