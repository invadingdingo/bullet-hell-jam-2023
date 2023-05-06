using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindPlayer : MonoBehaviour {
    public GameObject Find() {
        LayerMask playerMask = LayerMask.GetMask("Player");
        Collider2D hit = Physics2D.OverlapCircle(transform.position, 100f, playerMask);
        if (hit) {
            return hit.gameObject;
        } else {
            return null;
        }
    }
}
