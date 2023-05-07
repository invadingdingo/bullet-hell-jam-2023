using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCircle : MonoBehaviour {
    public CircleBulletPattern BulletPattern;
    public GameObject BulletPrefab;
    public int BulletSpawnDelay = 2;
    public float MoveRadius = 10f;
    public float MoveSpeed = 5f;
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

            Vector3 dirToPlayer = (PlayerTransform.position - transform.position).normalized;

            // spawn bullets
            CircleBulletPattern pattern = Instantiate(BulletPattern, transform.position, Quaternion.identity);

            pattern.Spawn(
                prefab: BulletPrefab,
                count: 10,
                radius: 5f,
                direction: dirToPlayer,
                speed: 20f
            );
        }
    }

    void OnDrawGizmos() {
        Gizmos.color = Color.yellow;
        int points = 20;
        float interval = 360f / points;
        for (int i = 0; i < points; i++) {
            Vector3 offset = Vector3.left * MoveRadius;
            Vector3 p0 = offset + transform.position + Polar.Circle(MoveRadius, interval * i);
            Vector3 p1 = offset + transform.position + Polar.Circle(MoveRadius, interval * (i + 1));
            Gizmos.DrawLine(p0, p1);
        }
    }
}
