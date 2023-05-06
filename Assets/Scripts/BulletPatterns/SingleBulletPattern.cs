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
        GameObject bullet = Instantiate(prefab, transform);
        bullet.transform.Rotate(0, 0, Vector3.SignedAngle(Vector3.up, direction, Vector3.forward));
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
