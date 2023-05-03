using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour {
    public SingleBulletPattern BulletPattern;
    public GameObject BulletPrefab;
    public float BulletSpawnDelay = 5f;
    public Transform SpriteTransform;
    public Transform EyeTransform;
    public Transform PlayerTransform;

    private float time;

    void Start() {
        time = BulletSpawnDelay;
    }

    void Update() {
        Vector3 dirToPlayer = (PlayerTransform.position - transform.position).normalized;

        // rotate sprite
        SpriteTransform.Rotate(0, 0, -45f * Time.deltaTime);

        // move eye
        EyeTransform.localPosition = dirToPlayer * 0.3f;

        // spawn bullets
        if (time > 0) {
            time -= Time.deltaTime;
        } else {
            time = BulletSpawnDelay;

            // juice up the scale
            Tween.Animate(this, 1.3f, 1f, 0.2f, Tween.EaseIn, s => {
                SpriteTransform.localScale = new Vector3(s, s, 1f);
            });

            // spawn bullets
            SingleBulletPattern pattern = Instantiate(BulletPattern, transform.position, Quaternion.identity);

            pattern.Spawn(
                prefab: BulletPrefab,
                direction: dirToPlayer,
                speed: 5f
            );
        }
    }
}
