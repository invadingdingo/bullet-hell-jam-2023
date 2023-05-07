using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class GlobalVolume : MonoBehaviour {
    private Bloom bloom;

    void Start() {
        BeatManager.instance.AddQuarter(OnBeat);

        Volume volume = GetComponent<Volume>();
        volume.profile.TryGet<Bloom>(out bloom);
    }

    void OnDestroy() {
        BeatManager.instance.RemoveQuarter(OnBeat);
    }

    void OnBeat() {
        Tween.Animate(this, 3f, 3.69f, 0.2f, Tween.EaseIn, b => {
            bloom.intensity.value = b;
        });  
    }
}
