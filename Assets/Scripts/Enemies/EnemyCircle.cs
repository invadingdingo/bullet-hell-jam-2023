using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCircle : MonoBehaviour {
    public CircleBulletPattern BulletPattern;
    public float BulletSpawnDelay = 2f;

    private float time;

    void Start() {
        time = BulletSpawnDelay;
    }

    void Update() {
        if (time > 0) {
            time -= Time.deltaTime;
        } else {
            time = BulletSpawnDelay;

            // spawn bullets
            CircleBulletPattern pattern = Instantiate(BulletPattern, transform.position, Quaternion.identity);

            pattern.Spawn(
                count: 10,
                radius: 5f,
                direction: Vector2.right,
                speed: 20f
            );
        }
    }
}
