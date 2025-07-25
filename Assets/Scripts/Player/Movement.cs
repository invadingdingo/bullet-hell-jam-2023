using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    public float speed;
    public Vector2 direction;

    [Header("Dash")]
    [SerializeField] private bool canDash = true;
    [SerializeField] private bool dashing;
    [SerializeField] private float dashPower;
    [SerializeField] private float dashDuration;
    [SerializeField] private float dashTimer;
    [SerializeField] private float dashBeatCooldown;
    [SerializeField] private float dashBeatCooldownCount;
    [SerializeField] private float dashDistance;
    [SerializeField] private GameObject dashClone;
    [SerializeField] public bool mousePressed;

    private Rigidbody2D rb;
    private int playerLayer;
    private int wallLayer;
    private int enemyBulletLayer;
    private LayerMask platformLayerMask;

    void Start() {
        BeatManager.instance.AddQuarter(RechargeDash);
        rb = GetComponent<Rigidbody2D>();
        playerLayer = LayerMask.NameToLayer("Player");
        wallLayer = LayerMask.NameToLayer("Wall");
        enemyBulletLayer = LayerMask.NameToLayer("Enemy Bullet");
        platformLayerMask = LayerMask.GetMask("Platform");

        dashPower = dashDistance / dashDuration;
        // dashDistance = (dashDuration * dashPower);
    }
    void Update() {
        if (!dashing)
            XYMovement();
        FaceMouse();
        Dash();
        SkipWave();
        
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
            rb.velocity = Vector2.zero;

            // Begin clone spawning coroutine
            StartCoroutine(Dashing());

            // Begin iFrames
            Physics2D.IgnoreLayerCollision(playerLayer, enemyBulletLayer, true); 

            // Raycast to see if there is a dashable platform.
            Collider2D hit = null;
        
            if (!GameManager.instance.mouseDash) {
                hit = Physics2D.OverlapCircle(transform.position + dashDistance * new Vector3(direction.x, direction.y, 0f).normalized, 0.1f, platformLayerMask);
                rb.velocity = direction * dashPower;
            } else {
                hit = Physics2D.OverlapCircle(transform.position + dashDistance * (Quaternion.Euler(0, 0, transform.eulerAngles.z + 90f) * Vector3.right).normalized, 0.1f, platformLayerMask);
                rb.velocity = (Quaternion.Euler(0, 0, transform.eulerAngles.z + 90f) * Vector3.right).normalized * dashPower;
            }

            // If ray lands on dashable object, disable collision for walls.
            if (hit != null) {
                Physics2D.IgnoreLayerCollision(playerLayer, wallLayer, true);
            }
        } else if (dashing) { // While dashing...
            if (dashTimer > dashDuration) {
                Physics2D.IgnoreLayerCollision(playerLayer, wallLayer, false);
                Physics2D.IgnoreLayerCollision(playerLayer, enemyBulletLayer, false); // End iFrames
                dashing = false;
            } else {
                dashTimer += Time.deltaTime;
            }
        } 
    }

    void RechargeDash() {
        if (!dashing && !canDash) {
            if (dashBeatCooldownCount < dashBeatCooldown) {
                dashBeatCooldownCount++;
            } else {
                dashBeatCooldownCount = 0;
                canDash = true;
            }
        }
    }

    void SkipWave() {
        if (Input.GetButtonDown("Skip")) {
            GameManager.instance.SkipWave();
        }
    }

    IEnumerator Dashing() {

        for(int c = 0; c < 4; c++) {
            Instantiate(dashClone, transform.position, transform.rotation);
            yield return new WaitForSeconds(dashDuration/4);
        }

        yield return null;
    }
}
