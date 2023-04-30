using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour {
    public Sprite LowDamageMask;
    public Sprite HighDamageMask;

    [Range(0.0f, 1.0f)]
    public float value = 0f;

    private SpriteMask spriteMask;
    private float oldValue = 1f;

    void Start() {
        spriteMask = GetComponent<SpriteMask>();
    }

    void Update() {
        if (value != oldValue) {
            if (value > 0.75f) {
                spriteMask.enabled = true;
                spriteMask.sprite = HighDamageMask;
            } else if (value > 0f) {
                spriteMask.enabled = true;
                spriteMask.sprite = LowDamageMask;
            } else {
                spriteMask.enabled = false;
            }
        }

        oldValue = value;
    }
}
