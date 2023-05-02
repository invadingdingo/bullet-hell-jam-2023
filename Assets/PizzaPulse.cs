using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PizzaPulse : MonoBehaviour {

    public GameObject pizza;
    //public BeatCounter beatC;

    void Start() {
        // BeatCounter.instance.AddListener(OnBeat); 
        BeatCounter.instance.AddListener(OnBeat);
    }
    void OnBeat() {
        Tween.Animate(this, 1f, 0.7f, 0.2f, Tween.EaseIn, s => {
            pizza.transform.localScale = new Vector3(s, s, 1f);
        });
    }
}
