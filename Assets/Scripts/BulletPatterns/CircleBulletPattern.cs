using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleBulletPattern : MonoBehaviour {
    public GameObject BulletPrefab;
    public Transform Orbit;

    private float speed;
    private Vector2 direction;

    public void Spawn(int count, float radius, Vector2 direction, float speed) {
        this.speed = speed;
        this.direction = direction;

        // spawn bullets in circle
        float interval = (Mathf.PI * 2.0f) / count;
        for (int i = 0; i < count; i++) {
            float x = radius * Mathf.Cos(interval * i);
            float y = radius * Mathf.Sin(interval * i);
            GameObject bullet = Instantiate(BulletPrefab, Orbit);
            bullet.transform.Translate(new Vector3(x, y, 0));
        }
    }

    void Start() {
        Spawn(9, 2f, Vector2.right, 5f);
    }

    void Update() {
        // destroy when all bullets are destroyed
        if (transform.childCount == 0) {
            Destroy(gameObject);
        }

        // rotate bullets in the orbit
        Orbit.Rotate(0, 0, speed * 15f * Time.deltaTime);

        // move bullet pattern
        transform.Translate(direction * speed * Time.deltaTime);
    }
}
