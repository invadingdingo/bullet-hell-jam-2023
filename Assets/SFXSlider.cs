using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SFXSlider : MonoBehaviour, IPointerUpHandler{
    
    public AudioClip sfxTest;
    public AudioSource aus;

    void IPointerUpHandler.OnPointerUp(PointerEventData eventData) {
        aus.clip = sfxTest;
        if (aus.isPlaying == false) {
            aus.Play();
        }
    }

}
