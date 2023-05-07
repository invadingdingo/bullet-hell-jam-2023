using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalScreen : MonoBehaviour {

    public float waitTime;

    void Start() {
        StartCoroutine(FinalScreenTime());
    }

    IEnumerator FinalScreenTime() {
        yield return new WaitForSeconds(waitTime);
        GameManager.instance.MainMenu();
    }
 
}
