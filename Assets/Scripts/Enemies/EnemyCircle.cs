using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCircle : MonoBehaviour {
    public CircleBulletPattern BulletPattern;
    public float BulletSpawnDelay = 2f;
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
        EyeTransform.localPosition = dirToPlayer * 0.35f;

        // spawn bullets
        if (time > 0) {
            time -= Time.deltaTime;
        } else {
            time = BulletSpawnDelay;

            // juice up the scale
            Tween.Animate(this, 1f, 1.3f, 0.2f, Tween.EaseInFlip, s => {
                SpriteTransform.localScale = new Vector3(s, s, 1f);
            });

            // spawn bullets
            CircleBulletPattern pattern = Instantiate(BulletPattern, transform.position, Quaternion.identity);

            pattern.Spawn(
                count: 5,
                radius: 5f,
                direction: dirToPlayer,
                speed: 20f
            );
        }
    }
}
