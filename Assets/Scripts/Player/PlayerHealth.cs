using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour {

    [Range(0, 3)]
    public int health; 

    private int maxHealth = 3;
    private LayerMask enemyBullet;
    private LayerMask playerLayer;
    public bool invulnerable = false;
    public float invulnerableTime;

    public GameObject[] slices;

    void Start() {
        playerLayer = LayerMask.NameToLayer("Player");
        enemyBullet = LayerMask.NameToLayer("Enemy Bullet");
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.layer == enemyBullet && !invulnerable) {
            invulnerable = true;
            RemoveHealth();
            StartCoroutine(Invulnerable());
        }
    }

    public void AddHealth(int h = 1) {
        if (health + h <= maxHealth) {
            health += h;
        } else if (health + h > maxHealth) {
            health = maxHealth;
        }

        UpdateSlices();
    }

    public void RemoveHealth(int h = 1) {
        if (health - h >= 0) {
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
