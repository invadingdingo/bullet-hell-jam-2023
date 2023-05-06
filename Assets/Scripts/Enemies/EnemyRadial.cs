using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRadial : MonoBehaviour {
    public RadialBulletPattern BulletPattern;
    public GameObject BulletPrefab;
    public int BulletSpawnDelay = 1;
    public Transform EyeTransform;
    public Transform PlayerTransform;

    private int beats;

    void Start() {
        beats = BulletSpawnDelay;
        PlayerTransform = GetComponent<FindPlayer>().Find().transform;
        BeatManager.instance.AddQuarter(Fire);
    }

    void OnDestroy() {
        BeatManager.instance.RemoveQuarter(Fire);
    }

    void Update() {
        Vector3 dirToPlayer = (PlayerTransform.position - transform.position).normalized;

        // rotate sprite
        transform.Rotate(0, 0, -45f * Time.deltaTime);

        // move eye
        EyeTransform.position = transform.position + dirToPlayer * 0.3f;
    }

    void Fire() {
        beats--;
        if (beats <= 0) {
            beats = BulletSpawnDelay;

            // juice up the scale
            Tween.Animate(this, 1.3f, 1f, 0.2f, Tween.EaseIn, s => {
                transform.localScale = new Vector3(s, s, 1f);
            });

            // spawn bullets
            RadialBulletPattern pattern = Instantiate(BulletPattern, transform.position, Quaternion.identity);

            pattern.Spawn(
                prefab: BulletPrefab,
                count: 6,
                radius: 3f,
                speed: 20f,
                rotationOffset: (transform.rotation.eulerAngles.z + 15f) * Mathf.Deg2Rad
            );
        }
    }
}
