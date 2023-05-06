using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SfxPlayer : MonoBehaviour {
    public void Play(AudioClip clip) {
        AudioSource aus = GetComponent<AudioSource>();
        aus.clip = clip;
        aus.Play();
        Destroy(gameObject, clip.length + 1f);
    }
}
