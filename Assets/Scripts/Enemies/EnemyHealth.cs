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

    public AudioClip killed;
    public AudioClip hit;
    private AudioSource aus;

    private SpriteMask spriteMask;
    private SpriteRenderer spriteRenderer;
    private float health;
    private Color originalColor;

    void Start() {
        aus = GetComponent<AudioSource>();
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

        health -= 1f;
        if (health <= 0f) {
            // if no health, DIE
            StartCoroutine(Die());
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

            aus.clip = hit;
            aus.Play();
        }
    }

    IEnumerator Die() {
        aus.clip = killed;
        aus.Play();
        // Disable enemy-ness
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<CircleCollider2D>().enabled = false;
        GetComponent<SpriteMask>().enabled = false;
        transform.GetChild(0).gameObject.SetActive(false);
        yield return new WaitForSeconds(killed.length);
        Destroy(gameObject);
    }
}
