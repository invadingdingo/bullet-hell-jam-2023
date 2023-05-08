using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRadial : MonoBehaviour {
    public RadialBulletPattern BulletPattern;
    public GameObject BulletPrefab;
    public int BulletSpawnDelay = 1;
    public float MoveScale = 7f;
    public float MoveSpeed = 30f;
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
        transform.position = startPosition + Polar.Flower(MoveScale, moveAngle - 30f);
        moveAngle += MoveSpeed * Time.deltaTime;
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
            Vector3 p0 = transform.position + Polar.Flower(MoveScale, interval * i);
            Vector3 p1 = transform.position + Polar.Flower(MoveScale, interval * (i + 1));
            Gizmos.DrawLine(p0, p1);
        }
    }
}
