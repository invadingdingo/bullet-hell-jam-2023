using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PizzaPulse : MonoBehaviour {
    public GameObject pizza;

    void Start() {
        BeatManager.instance.AddQuarter(OnBeat);
    }

    void OnDestroy() {
        BeatManager.instance.RemoveQuarter(OnBeat);
    }

    void OnBeat() {
        Tween.Animate(this, 0.8f, 1f, 0.2f, Tween.EaseIn, s => {
            pizza.transform.localScale = new Vector3(s, s, 1f);
        });
    }
}
