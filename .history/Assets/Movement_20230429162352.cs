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

        // WASD movement
        direction.x = Input.GetAxisRaw("Horizontal");
        direction.y = Input.GetAxisRaw("Vertical");
        direction = direction.normalized;

        // Apply movement
        rb.velocity = speed * direction;

        // Change facing direction to mouse.
        

        
    }

    void Movement() {

    }

    void FaceMouse() {
        Vector3 mouseScreen = Input.mousePosition;
        Vector3 mouse = Camera.main.ScreenToWorldPoint(mouseScreen);

        transform.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(mouse.y - transform.position.y, mouse.x - transform.position.x) * Mathf.Rad2Deg - 90);
    }
}
