using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(SpriteMask))]
[RequireComponent(typeof(Rigidbody2D))]
public class EnemyHealth : MonoBehaviour {
    public float MaxHealth = 10f;
    public Sprite LowDamageMask;
    public Sprite HighDamageMask;
    public AudioClip HitAudio;
    public AudioClip KilledAudio;

    private SpriteMask spriteMask;
    private SpriteRenderer spriteRenderer;
    private float health;
    private Color originalColor;

    void Start() {
        spriteMask = GetComponent<SpriteMask>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        health = MaxHealth;
        originalColor = spriteRenderer.color;
    }

    void OnTriggerEnter2D(Collider2D other) {
        // trigger white flash
        Tween.Animate(this, 0f, 1f, 0.2f, Tween.EaseIn, c => {
            spriteRenderer.color = Color.Lerp(Color.white, originalColor, c);
        });

        if (GameManager.instance.easyMode)
            health -= 2f;
        else 
            health -= 1f;

        if (health <= 0f) {
            // if no health, DIE
            GameManager.instance.PlaySfx(KilledAudio);
            Destroy(gameObject);
        } else {
            // if has health, visualize it
            float damage = 1f - health / MaxHealth;
            if (damage > 0.75f) {
                spriteMask.enabled = true;
                spriteMask.sprite = HighDamageMask;
            } else if (damage > 0f) {
                spriteMask.enabled = true;
                spriteMask.sprite = LowDamageMask;
            } else {
                spriteMask.enabled = false;
            }

            GameManager.instance.PlaySfx(HitAudio);
        }
    }
}
