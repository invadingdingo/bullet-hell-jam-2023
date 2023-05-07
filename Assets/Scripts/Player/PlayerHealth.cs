using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour {
    [Range(0, 3)]
    public int health; 
    private int maxHealth = 3;
    public bool invulnerable = false;
    public float invulnerableTime;
    public GameObject[] slices;
    public GameObject PlayerSprite;

    private LayerMask enemyBulletLayer;
    private LayerMask playerLayer;
    private SpriteRenderer spriteRenderer;
    private int invulnerableBeats = 0;
    private Color originalColor;

    void Start() {
        playerLayer = LayerMask.NameToLayer("Player");
        enemyBulletLayer = LayerMask.NameToLayer("Enemy Bullet");
        spriteRenderer = PlayerSprite.GetComponent<SpriteRenderer>();
        originalColor = spriteRenderer.color;
        BeatManager.instance.AddTriplet(Flash);
    }

    void OnTriggerEnter2D(Collider2D other) {
        // Physics2D.IgnoreLayerCollision(playerLayer, enemyBulletLayer, true);
        if (!invulnerable) {
            invulnerable = true;
            GameManager.instance.mx.SetFloat("LowPass", 500); // Dampen audio.
            Tween.Animate(this, 1f, 0f, 1f, Tween.EaseIn, c => {
                GameManager.instance.mx.SetFloat("Distortion", c); // Fix audio.
            });
            invulnerableBeats = 6;
            RemoveHealth();
        }
    }

    public void AddHealth(int h = 1) {
        if (health + h <= maxHealth) {
            health += h;
        } else if (health + h > maxHealth) {
            health = maxHealth;
        }

        Tween.Animate(this, 0f, 1f, 1f, Tween.EaseIn, c => {
            spriteRenderer.color = Color.Lerp(new Color(0, 1f, 0.3f), originalColor, c);
        });

        UpdateSlices();
    }

    public void RemoveHealth(int h = 1) {
        if (health - h > 0) {
            health -= h;
            UpdateSlices();
        } else {
            GameManager.instance.GameOver();
        }
    }

    void UpdateSlices() {
        for(int i = 0; i < maxHealth; i++) {
            if (i <= health - 1) {
                slices[i].SetActive(true);
            } else {
                slices[i].SetActive(false);
            }
        }
    }

    void Flash() {
        if (invulnerableBeats > 0) {
            Tween.Animate(this, 0f, 1f, 0.2f, Tween.EaseIn, c => {
                spriteRenderer.color = Color.Lerp(Color.black, originalColor, c);
            });
            invulnerableBeats--;
        } else if (invulnerableBeats > -1) {
            Tween.Animate(this, 300f, 220000f, 0.2f, Tween.EaseIn, c => {
                GameManager.instance.mx.SetFloat("LowPass", c); // Fix audio.
            });
            invulnerable = false;
            // Physics2D.IgnoreLayerCollision(playerLayer, enemyBulletLayer, false);
            invulnerableBeats--; //Just so this only plays once.
        }
    }
}
