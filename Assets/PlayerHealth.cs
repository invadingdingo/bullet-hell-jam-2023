using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour {

    [Range(0, 3)]
    public int health; 

    private int maxHealth = 3;

    public GameObject[] slices;

    void Update() {
        UpdateSlices(); // This update method is just for testing. it can be removed.
    }

    public void AddHealth(int h = 1) {
        if (health + h <= maxHealth) {
            health += h;
            UpdateSlices();
        }
    }

    public void RemoveHealth(int h = 1) {
        if (health - h > 0) {
            health -= h;
            UpdateSlices();
        }
    }

    void UpdateSlices() {
        for(int i = 0; i < maxHealth; i++) {
            if (i <= health - 1) {
                slices[i].SetActive(true);
            } else {
                slices[i].SetActive(false);
            }
        }
    }
}
