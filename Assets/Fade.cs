using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fade : MonoBehaviour {

    public float fadeTime = 1;

    void Update() {
        if (fadeTime > 0) {
            Tween.Animate(this, 1f, 0f, fadeTime, Tween.EaseOut, c => {
                GetComponentInChildren<SpriteRenderer>().color = new Color(0, 135f, 135f, c);
            });
            fadeTime -= Time.deltaTime;
        } else {
            Destroy(gameObject);
        }
    }
    
}
