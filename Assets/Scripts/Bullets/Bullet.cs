using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
    public GameObject BulletHit;

    void OnTriggerEnter2D(Collider2D other) {
        Instantiate(BulletHit, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
