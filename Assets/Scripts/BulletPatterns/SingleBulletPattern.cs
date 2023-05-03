using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleBulletPattern : MonoBehaviour {
    private Vector2 direction;
    private float speed;

    public void Spawn(GameObject prefab, Vector2 direction, float speed) {
        this.speed = speed;
        this.direction = direction;

        // spawn bullet
        Instantiate(prefab, transform);
    }

    void Update() {
        // destroy when all bullets are destroyed
        if (transform.childCount == 0) {
            Destroy(gameObject);
        }

        // move bullet
        transform.Translate(direction * speed * Time.deltaTime);
    }
}
