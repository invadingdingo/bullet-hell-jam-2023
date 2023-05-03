using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
    void OnColliderEnter2D(Collider2D other) {
        Debug.Log("Trigger");
        if (other.tag == "BulletBarrier")
            Destroy(gameObject);
    }
}
