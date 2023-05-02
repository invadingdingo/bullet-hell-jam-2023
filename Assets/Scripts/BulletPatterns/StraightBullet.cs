using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StraightBullet : MonoBehaviour {

    private float speed;
    private Vector2 direction;
    public void Spawn(Vector2 direction, float speed) {
        this.speed = speed;
        this.direction = direction;
    }

    void Update() {
        transform.Translate(direction * speed * Time.deltaTime);
    }
}
