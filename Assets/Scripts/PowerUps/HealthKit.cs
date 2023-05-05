using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthKit : MonoBehaviour {

    public int restoreAmount = 3;
    public AudioClip soundEffect;

    void OnTriggerEnter2D(Collider2D other) {
        Debug.Log("e");
        if (other.gameObject.layer == LayerMask.NameToLayer("Player")) {
            other.GetComponent<PlayerHealth>().AddHealth(restoreAmount);
            StartCoroutine(DestroyThis());
        }
    }
    
    IEnumerator DestroyThis() {
        GetComponent<AudioSource>().clip = soundEffect;
        GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(soundEffect.length);
        BeatManager.instance.RemoveQuarter(GetComponent<PizzaPulse>().OnBeat);
        Destroy(gameObject);
        yield return null;
    }

}
