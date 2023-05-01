using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    public float speed;
    public Rigidbody2D rb;
    public Vector2 direction;

    [Header("Dash")]
    [SerializeField] private bool mouseDirectionalDash;
    [SerializeField] private bool canDash = true;
    [SerializeField] private bool dashing;
    [SerializeField] private float dashPower;
    [SerializeField] private float dashDuration;
    [SerializeField] private float dashCooldown;
    [SerializeField] private float dashCooldownTimer;
    [SerializeField] private float dashTimer;

    [SerializeField] private float dashDistance;

    void Start() {
        rb = GetComponent<Rigidbody2D>();
        dashDistance = (dashDuration * dashPower);
    }
    void Update() {
        //Debug.Log((Quaternion.Euler(0, 0, transform.eulerAngles.z) * Vector3.right).normalized);
        if (!dashing)
            XYMovement();
        FaceMouse();
        Dash();
        
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
        if (Input.GetButton("Dash") && canDash) { // Start dash.
            dashing = true;
            canDash = false;
            dashTimer = 0;
            dashCooldownTimer = 0;
            rb.velocity = Vector2.zero;

            // Raycast to see if there is a dashable platform.
            Collider2D hit = null;
        
            if (!mouseDirectionalDash) {
                // 4.2f is approximately the length of the dash. This will need to be changed if we change dash values. 
                hit = Physics2D.OverlapCircle(transform.position + dashDistance * new Vector3(direction.x, direction.y, 0f).normalized, 0.1f);
                rb.velocity = direction * dashPower;
            } else {
                hit = Physics2D.OverlapCircle(transform.position + dashDistance * (Quaternion.Euler(0, 0, transform.eulerAngles.z + 90f) * Vector3.right).normalized, 0.1f);
                rb.velocity = (Quaternion.Euler(0, 0, transform.eulerAngles.z + 90f) * Vector3.right).normalized * dashPower;
            }

            // If ray lands on dashable object, disable collision for walls.
            if (hit != null) {
                if (hit.gameObject.tag == "Dashable") {
                    Physics2D.IgnoreLayerCollision(3, 6, true); // Disable collision between Player (3) and Wall (6)
                }
            }

        } else if (dashing) { // While dashing...
            if (dashTimer > dashDuration) {
                Physics2D.IgnoreLayerCollision(3, 6, false); // Reenable collision between Player (3) and Wall (6)
                dashing = false;
            } else {
                dashTimer += Time.deltaTime;
            }
        } else { // Increment cooldown timer.
            if (dashCooldownTimer < dashCooldown) {
                dashCooldownTimer += Time.deltaTime;
            } else {
                canDash = true;
            }
        }
    }
}
