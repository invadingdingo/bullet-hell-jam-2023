using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadialBulletPattern : MonoBehaviour {
    private float speed;

    public void Spawn(GameObject prefab, int count, float radius, float speed, float rotationOffset) {
        this.speed = speed;

        // spawn bullets in circle
        float interval = 360f / count;
        for (int i = 0; i < count; i++) {
            GameObject bullet = Instantiate(prefab, transform);
            bullet.transform.Translate(Polar.Circle(radius, rotationOffset + interval * i));
        }
    }

    void Update() {
        // destroy when all bullets are destroyed
        if (transform.childCount == 0) {
            Destroy(gameObject);
        }

        // move all bullets away from origin
        for (int i = 0; i < transform.childCount; i++) {
            Transform child = transform.GetChild(i);
            Vector3 dir = (child.position - transform.position).normalized;
            child.Translate(dir * speed * Time.deltaTime);
        }
    }
}
