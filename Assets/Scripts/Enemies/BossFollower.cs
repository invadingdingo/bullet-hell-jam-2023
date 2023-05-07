using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFollower : MonoBehaviour {
    public SingleBulletPattern BulletPattern;
    public GameObject BulletPrefab;
    public int BulletSpawnDelay = 2;
    public float MoveSpeed = 5f;
    public Transform EyeTransform;
    public Transform PlayerTransform;

    private int beats;

    void Start() {
        beats = 0;
        PlayerTransform = GetComponent<FindPlayer>().Find().transform;
        BeatManager.instance.AddQuarter(Fire);
    }

    void OnDestroy() {
        BeatManager.instance.RemoveQuarter(Fire);
    }

    void Update() {
        // rotate sprite
        transform.Rotate(0, 0, -45f * Time.deltaTime);

        // move eye
        EyeTransform.position = transform.position + DirToPlayer() * 0.3f;

        // move enemy
        transform.position = transform.position + DirToPlayer() * MoveSpeed * Time.deltaTime;
    }

    void Fire() {
        beats--;
        if (beats <= 0) {
            beats = BulletSpawnDelay;

            // juice up the scale
            Tween.Animate(this, 3.1f, 3f, 0.2f, Tween.EaseIn, s => {
                transform.localScale = new Vector3(s, s, 1f);
            });

            // spawn bullets
            SingleBulletPattern pattern = Instantiate(BulletPattern, transform.position, Quaternion.identity);

            pattern.Spawn(
                prefab: BulletPrefab,
                direction: DirToPlayer(),
                speed: 15f
            );
        }
    }

    Vector3 DirToPlayer() {
        if (PlayerTransform) {
            return (PlayerTransform.position - transform.position).normalized;
        } else {
            return (Vector3.zero - transform.position).normalized;
        }
    }
}
