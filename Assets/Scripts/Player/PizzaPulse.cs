using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PizzaPulse : MonoBehaviour {

    public GameObject pizza;

    void Start() {
        BeatCounter.instance.AddListener(OnBeat);
    }
    void OnBeat() {
        Tween.Animate(this, 0.5f, 1f, 0.2f, Tween.EaseIn, s => {
            pizza.transform.localScale = new Vector3(s, s, 1f);
        });
    }
}
