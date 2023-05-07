using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleBulletPattern : MonoBehaviour {
    public Transform Orbit;

    private float speed;
    private Vector2 direction;

    public void Spawn(GameObject prefab, int count, float radius, Vector2 direction, float speed) {
        this.speed = speed;
        this.direction = direction;

        // spawn bullets in circle
        float interval = 360f / count;
        for (int i = 0; i < count; i++) {
            GameObject bullet = Instantiate(prefab, Orbit);
            bullet.transform.Translate(Polar.Circle(radius, interval * i));
        }
    }

    void Update() {
        // destroy when all bullets are destroyed
        if (Orbit.childCount == 0) {
            Destroy(gameObject);
        }

        // rotate bullets in the orbit
        Orbit.Rotate(0, 0, speed * 5f * Time.deltaTime);

        // move bullet pattern
        transform.Translate(direction * speed * Time.deltaTime);
    }
}
