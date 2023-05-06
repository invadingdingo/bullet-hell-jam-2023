using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthKit : MonoBehaviour {
    public int restoreAmount = 3;

    void OnDestroy() {
        GameObject player = GetComponent<FindPlayer>().Find();
        if (player) {
            player.GetComponent<PlayerHealth>().AddHealth(restoreAmount);
        }
    }
}
