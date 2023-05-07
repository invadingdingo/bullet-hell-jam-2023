using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class EnemySpawnVisual : MonoBehaviour {
    private SpriteRenderer spriteRenderer;
    private Color originalColor;

    void Start() {
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalColor = spriteRenderer.color;
        BeatManager.instance.AddQuarter(Flash);
    }

    void OnDestroy() {
        BeatManager.instance.RemoveQuarter(Flash);
    }

    void Flash() {
        Tween.Animate(this, 0f, 1f, 0.3f, Tween.EaseIn, c => {
            spriteRenderer.color = Color.Lerp(Color.black, originalColor, c);
        });
    }
}
