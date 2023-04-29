using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    public float speed;
    public Rigidbody2D rb;
    public Vector2 direction;

    [Header("Dash")]
    [SerializeField] private bool canDash;
    [SerializeField] private bool dashing;
    [SerializeField] private float dashPower;
    [SerializeField] private float dashDuration;
    [SerializeField] private float dashCooldown;
    [SerializeField] private float dashCooldownTimer;
    [SerializeField] private float dashTimer;
    [SerializeField] private int facing;

    void Start() {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update() {
        if (!dashing)
            XYMovement();
        FaceMouse();
        
    }

    void XYMovement() {
        direction.x = Input.GetAxisRaw("Horizontal");
        direction.y = Input.GetAxisRaw("Vertical");
        direction = direction.normalized;

        rb.velocity = speed * direction;
    }

    void FaceMouse() {
        Vector3 mouseScreen = Input.mousePosition;
        Vector3 mouse = Camera.main.ScreenToWorldPoint(mouseScreen);

        transform.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(mouse.y - transform.position.y, mouse.x - transform.position.x) * Mathf.Rad2Deg - 90);
    }
     
    void Dash() {
        if (Input.GetKey(KeyCode.LeftShift) && canDash) {
            dashing = true;
            canDash = false;
            dashTimer = 0;
            dashCooldownTimer = 0;

            rb.velocity = Vector2.zero;

            rb.velocity = direction * dashPower;

        } else if (dashing) {

        }
    }
}
