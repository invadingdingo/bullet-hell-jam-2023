using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossWaver : MonoBehaviour {
    public RadialBulletPattern BulletPattern;
    public GameObject BulletPrefab;
    public int BulletSpawnDelay = 0;
    public float MoveScale = 7f;
    public float MoveSpeed = 10f;
    public Transform EyeTransform;
    public Transform PlayerTransform;

    private int beats;
    private Vector3 startPosition;
    private float moveAngle;

    void Start() {
        beats = 0;
        startPosition = transform.position;
        moveAngle = 0f;
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
        Vector3 offset = Vector3.left * MoveScale;
        transform.position = startPosition + offset + Polar.Circle(MoveScale, moveAngle);
        moveAngle -= MoveSpeed * Time.deltaTime;
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
            RadialBulletPattern pattern = Instantiate(BulletPattern, transform.position, Quaternion.identity);

            pattern.Spawn(
                prefab: BulletPrefab,
                count: 12,
                radius: 3f,
                speed: 20f,
                rotationOffset: transform.rotation.eulerAngles.z + 15f
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

    void OnDrawGizmosSelected() {
        Gizmos.color = Color.yellow;
        int points = 100;
        float interval = 360f / points;
        for (int i = 0; i < points; i++) {
            Vector3 offset = Vector3.left * MoveScale;
            Vector3 p0 = offset + transform.position + Polar.Circle(MoveScale, interval * i);
            Vector3 p1 = offset + transform.position + Polar.Circle(MoveScale, interval * (i + 1));
            Gizmos.DrawLine(p0, p1);
        }
    }
}
