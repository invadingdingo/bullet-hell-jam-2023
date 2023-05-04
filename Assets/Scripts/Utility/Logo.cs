using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Logo : MonoBehaviour {

    private float timer = 2f;
    private float time = 2f;
    void Update() {

        if (timer >= time) {
            Tween.Animate(this, 6f, 5f, 2f, Tween.Spike, s => {
                transform.localScale = new Vector3(s + 1, s, 1f);
            });
            timer = 0;
        } else {
            timer += Time.deltaTime;
        }
    }
}
