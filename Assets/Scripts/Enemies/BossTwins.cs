using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTwins : MonoBehaviour {
    public RadialBulletPattern BulletPattern;
    public GameObject BulletPrefab;
    public int BulletSpawnDelay = 1;
    public float MoveScale = 7f;
    public float MoveSpeed = 30f;
    public float MoveOffset = 0f;
    public Vector3 MoveOffsetDir = Vector3.down;
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
        Vector3 offset = MoveOffsetDir * MoveScale;
        Quaternion rot = Quaternion.Euler(0f, 0f, 90f);
        transform.position = startPosition + offset + rot * Polar.Line(MoveScale, moveAngle + MoveOffset);
        moveAngle += MoveSpeed * Time.deltaTime;
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
                count: 6,
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
            Vector3 offset = MoveOffsetDir * MoveScale;
            Quaternion rot = Quaternion.Euler(0f, 0f, 90f);
            Vector3 p0 = offset + transform.position + rot * Polar.Line(MoveScale, interval * i + MoveOffset);
            Vector3 p1 = offset + transform.position + rot * Polar.Line(MoveScale, interval * (i + 1) + MoveOffset);
            Gizmos.DrawLine(p0, p1);
        }
    }
}
