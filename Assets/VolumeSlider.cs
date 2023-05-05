using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class VolumeSlider : MonoBehaviour, IPointerDownHandler, IPointerUpHandler {
    
    public AudioClip musicTest;
    public AudioSource aus;

    void IPointerDownHandler.OnPointerDown(PointerEventData eventData) {
        aus.clip = musicTest;
        if (aus.isPlaying == false) {
            aus.Play();
        }
    }

    void IPointerUpHandler.OnPointerUp(PointerEventData eventData) {
        aus.Stop();    
    }

}
