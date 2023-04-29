using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

public float speed;
public Rigidbody2D rb;
public Vector2 direction;

    void Start() {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update() {
        direction.x = Input.GetAxisRaw("horizontal");
        direction.y = Input.GetAxisRaw("vertical");
        direction = direction.normalized;

        rb.velocity = speed * direction;
        
    }
}
