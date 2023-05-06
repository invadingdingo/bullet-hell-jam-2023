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
        Physics2D.IgnoreLayerCollision(playerLayer, enemyBulletLayer, true);
        invulnerableBeats = 6;
        RemoveHealth();
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
        } else {
            Physics2D.IgnoreLayerCollision(playerLayer, enemyBulletLayer, false);
        }
    }

    IEnumerator Invulnerable() {
        Color prev = GetComponentInChildren<SpriteRenderer>().color; // Save color

        for (int c = 0; c < 20; c++) {
            if (c % 2 == 0) 
                GetComponentInChildren<SpriteRenderer>().color = prev;
            else 
                GetComponentInChildren<SpriteRenderer>().color = Color.white;

            yield return new WaitForSeconds(invulnerableTime/20);
        }

        invulnerable = false;
        GetComponentInChildren<SpriteRenderer>().color = prev; // Turn color back
        yield return null;
    }
}
