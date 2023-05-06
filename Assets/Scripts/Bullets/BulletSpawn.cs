using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawn : MonoBehaviour {
    public RadialBulletPattern BulletPattern;
    public GameObject BulletPrefab;
    public int BulletSpawnDelay = 2;

    private int beats;

    void Start() {
        beats = BulletSpawnDelay;
        BeatManager.instance.AddQuarter(Fire);
    }

    void OnDestroy() {
        BeatManager.instance.RemoveQuarter(Fire);
    }

    void Update() {
        // rotate sprite
        transform.Rotate(0, 0, -45f * Time.deltaTime);
    }

    void Fire() {
        beats--;
        if (beats <= 0) {
            beats = BulletSpawnDelay;

            // spawn bullets
            RadialBulletPattern pattern = Instantiate(BulletPattern, transform.position, Quaternion.identity);

            pattern.Spawn(
                prefab: BulletPrefab,
                count: 4,
                radius: 0.1f,
                speed: 20f,
                rotationOffset: (transform.rotation.eulerAngles.z + 15f) * Mathf.Deg2Rad
            );
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        Destroy(gameObject);
    }
}
